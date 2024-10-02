using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.DataTransferObjects.Role.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoleReadOnlyRepository
    {
        Task<RequestResult<RoleDto?>> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoleDto>>> GetRoleWithPaginationByAdminAsync(
            ViewRoleWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
