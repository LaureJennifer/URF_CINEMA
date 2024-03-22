using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
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
                var filmSchedule = _appReadOnlyDbContext.FilmScheduleEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmScheduleDto>(_mapper.ConfigurationProvider);
                if (request.ShowDate != null)
                {
                    filmSchedule = filmSchedule.Where(x => x.ShowDate == request.ShowDate);
                }
                if (request.ShowTime != null)
                {
                    filmSchedule = filmSchedule.Where(x => x.ShowTime == request.ShowTime);
                }
                if (request.Status != null)
                {
                    filmSchedule = filmSchedule.Where(x => x.Status == request.Status);
                }
                var result = await filmSchedule.PaginateAsync(request, cancellationToken);
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
