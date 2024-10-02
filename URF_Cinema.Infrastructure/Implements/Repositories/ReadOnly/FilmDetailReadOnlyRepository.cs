using AutoMapper;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Infrastructure.Extensions;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmDetailReadOnlyRepository : IFilmDetailReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public FilmDetailReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<FilmDetailDto?>> GetFilmDetailByIdAsync(Guid idFilmDetail, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail = await _appReadOnlyDbContext.FilmDetailEntities.AsNoTracking().Where(c => c.Id == idFilmDetail).ProjectTo<FilmDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmDetailDto?>.Succeed(filmDetail);
            }
            catch (Exception e)
            {
                return RequestResult<FilmDetailDto?>.Fail(_localizationService["Film detail is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film detail"
                    }
                });
            }
        }
        public async Task<RequestResult<PaginationResponse<FilmDetailDto>>> GetFilmDetailWithPaginationByAdminAsync(ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetails = _appReadOnlyDbContext.FilmDetailEntities.AsNoTracking().ProjectTo<FilmDetailDto>(_mapper.ConfigurationProvider);
                if (request.FilmId!=null)
                {
                    filmDetails = filmDetails.Where(x => x.FilmId == request.FilmId);
                }
                if (request.FilmScheduleId != null)
                {
                    filmDetails = filmDetails.Where(x => x.FilmScheduleId == request.FilmScheduleId);
                }
                if (!string.IsNullOrWhiteSpace(request.FilmName))
                {
                    filmDetails = filmDetails.Where(x => x.Title == request.FilmName);
                }
                if (request.Status !=null)
                {
                    filmDetails = filmDetails.Where(x => x.Status == request.Status);
                }
                var result = await filmDetails.PaginateAsync(request, cancellationToken);


                return RequestResult<PaginationResponse<FilmDetailDto>>.Succeed(new PaginationResponse<FilmDetailDto>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {
                return RequestResult<PaginationResponse<FilmDetailDto>>.Fail(_localizationService["List of film detail are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film detail"
                    }
                });
            }
        }
    }
}
