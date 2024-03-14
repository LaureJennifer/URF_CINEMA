using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IDepartmentReadOnlyRepository
    {
        Task<RequestResult<DepartmentDto?>> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<DepartmentDto>>> GetDepartmentWithPaginationByAdminAsync(
            ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
