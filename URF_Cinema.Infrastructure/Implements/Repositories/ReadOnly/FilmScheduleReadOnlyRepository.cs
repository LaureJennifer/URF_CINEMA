using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmScheduleReadOnlyRepository : IFilmScheduleReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public FilmScheduleReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<FilmScheduleDto?>> GetFilmScheduleByIdAsync(Guid idFilmSchedule, CancellationToken cancellationToken)
        {
            try
            {
                var filmSchedule = await _appReadOnlyDbContext.FilmScheduleEntities.AsNoTracking().Where(c => c.Id == idFilmSchedule && !c.Deleted).ProjectTo<FilmScheduleDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmScheduleDto?>.Succeed(filmSchedule);
            }
            catch (Exception e)
            {
                return RequestResult<FilmScheduleDto?>.Fail(_localizationService["Film schedule is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film schedule"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<FilmScheduleDto>>> GetFilmScheduleWithPaginationByAdminAsync(ViewFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmSchedules = _appReadOnlyDbContext.FilmScheduleEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmScheduleDto>(_mapper.ConfigurationProvider);
                if (request.ShowDate != null)
                {
                    filmSchedules = filmSchedules.Where(x => x.ShowDate == request.ShowDate);
                }
                if (request.ShowTime != null)
                {
                    filmSchedules = filmSchedules.Where(x => x.ShowTime == request.ShowTime);
                }
                if (request.Status != null)
                {
                    filmSchedules = filmSchedules.Where(x => x.Status == request.Status);
                }
                var result = await filmSchedules.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmScheduleDto>>.Succeed(new PaginationResponse<FilmScheduleDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmScheduleDto>>.Fail(_localizationService["List of film schedule are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film schedule"
                    }
                });
            }
        }
    }
}
