using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Department;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using URF_Cinema.Application.DataTransferObjects.Film;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class DepartmentReadOnlyRepository : IDepartmentReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public DepartmentReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<DepartmentDto?>> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            try
            {
                var department = await _appReadOnlyDbContext.DepartmentEntities.AsNoTracking().Where(c => c.Id == idDepartment && !c.Deleted).ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<DepartmentDto?>.Succeed(department);
            }
            catch (Exception e)
            {
                return RequestResult<DepartmentDto?>.Fail(_localizationService["Department is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Department"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<DepartmentDto>>> GetDepartmentWithPaginationByAdminAsync(ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var departments = _appReadOnlyDbContext.DepartmentEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    departments = departments.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    departments = departments.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.Address))
                {
                    departments = departments.Where(x => x.Address.ToLower().Contains(request.Address.ToLower()));
                }
                var result = await departments.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<DepartmentDto>>.Succeed(new PaginationResponse<DepartmentDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<DepartmentDto>>.Fail(_localizationService["List of department are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of department"
                    }
                });
            }
        }
    }
}
