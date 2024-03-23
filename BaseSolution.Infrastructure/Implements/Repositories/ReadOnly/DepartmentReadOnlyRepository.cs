using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.Film;
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
