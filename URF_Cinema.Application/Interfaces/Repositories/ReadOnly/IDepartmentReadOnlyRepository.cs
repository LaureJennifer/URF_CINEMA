using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Department;
using URF_Cinema.Application.DataTransferObjects.Department.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IDepartmentReadOnlyRepository
    {
        Task<RequestResult<DepartmentDto?>> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<DepartmentDto>>> GetDepartmentWithPaginationByAdminAsync(
            ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
