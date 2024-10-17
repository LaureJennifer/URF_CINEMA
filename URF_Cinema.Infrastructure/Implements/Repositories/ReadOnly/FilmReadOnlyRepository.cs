using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.DataTransferObjects.Department;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmReadOnlyRepository : IFilmReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        
        public FilmReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, ILocalizationService localizationService, IMapper mapper)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;       
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async Task<RequestResult<FilmDto?>> GetFilmByIdAsync(Guid idFilm, CancellationToken cancellationToken)
        {
            try
            {
                var film = await _appReadOnlyDbContext.FilmEntities.AsNoTracking().Where(c => c.Id == idFilm && !c.Deleted).ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<FilmDto?>.Succeed(film);
            }
            catch (Exception e)
            {
                return RequestResult<FilmDto?>.Fail(_localizationService["Film is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Film"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmWithPaginationByAdminAsync(ViewFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var films = _appReadOnlyDbContext.FilmEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Title))
                {
                    films = films.Where(x => x.Title.ToLower().Contains(request.Title.ToLower()));
                }
                if (request.Code != null)
                {
                    films = films.Where(x => x.Code == request.Code);
                }
                var result = await films.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmDto>>.Succeed(new PaginationResponse<FilmDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmDto>>.Fail(_localizationService["List of film are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film"
                    }
                });
            }
        }
        public async Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmsWithDepartmentPaginationAsync(ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var films = _appReadOnlyDbContext.DepartmentEntities.AsNoTracking()
                .Where(x => x.Name.ToLower() == request.Name!.ToLower()).SelectMany(x=>x.DepartmentFilms).Select(x=>x.Film)
                .ProjectTo<FilmDto>(_mapper.ConfigurationProvider);

                var result = await films.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<FilmDto>>.Succeed(new PaginationResponse<FilmDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<FilmDto>>.Fail(_localizationService["List of film are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of film"
                    }
                });
            }
        }
    }
}
