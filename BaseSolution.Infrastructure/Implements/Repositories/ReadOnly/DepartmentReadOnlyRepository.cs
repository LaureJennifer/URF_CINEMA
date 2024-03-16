using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services;
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
        public Task<RequestResult<DepartmentDto?>> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PaginationResponse<DepartmentDto>>> GetDepartmentWithPaginationByAdminAsync(ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
