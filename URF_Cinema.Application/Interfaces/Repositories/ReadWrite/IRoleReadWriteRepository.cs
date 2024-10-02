using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRoleReadWriteRepository
    {
        Task<RequestResult<Guid>> AddRoleAsync(RoleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateRoleAsync(RoleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteRoleAsync(RoleDeleteRequest request, CancellationToken cancellationToken);
    }
}
