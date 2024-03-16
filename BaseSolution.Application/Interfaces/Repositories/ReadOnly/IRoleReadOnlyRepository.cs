using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.DataTransferObjects.Role.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoleReadOnlyRepository
    {
        Task<RequestResult<RoleDto?>> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoleDto>>> GetRoleWithPaginationByAdminAsync(
            ViewRoleWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
