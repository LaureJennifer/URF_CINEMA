using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using static URF_Cinema.Application.ValueObjects.Common.LocalizationString;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class DepartmentFilmReadOnlyRepository : IDepartmentFilmReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public DepartmentFilmReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<DepartmentFilmDto?>> GetDepartmentFilmByIdAsync(Guid idDepartmentFilm, CancellationToken cancellationToken)
        {
            try
            {
                var departmentFilm = await _appReadOnlyDbContext.DepartmentFilmEntities.AsNoTracking().Where(c => c.Id == idDepartmentFilm).ProjectTo<DepartmentFilmDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<DepartmentFilmDto?>.Succeed(departmentFilm);
            }
            catch (Exception e)
            {
                return RequestResult<DepartmentFilmDto?>.Fail(_localizationService["Department film is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Department film"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<DepartmentFilmDto>>> GetDepartmentFilmWithPaginationByAdminAsync(ViewDepartmentFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {              
                var departmentFilms = _appReadOnlyDbContext.DepartmentFilmEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<DepartmentFilmDto>(_mapper.ConfigurationProvider);
                if (request.DepartmentId != null)
                {
                    departmentFilms = departmentFilms.Where(x => x.DepartmentId==request.DepartmentId);
                }
                if (!string.IsNullOrWhiteSpace(request.DepartmentName))
                {
                    departmentFilms = departmentFilms.Where(x => x.DepartmentName.ToLower().Contains(request.DepartmentName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.FilmTitle))
                {
                    departmentFilms = departmentFilms.Where(x => x.FilmTitle.ToLower().Contains(request.FilmTitle.ToLower()));
                }
                
                var result = await departmentFilms.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<DepartmentFilmDto>>.Succeed(new PaginationResponse<DepartmentFilmDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<DepartmentFilmDto>>.Fail(_localizationService["List of department film are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of department film"
                    }
                });
            }
        }
    }
}
