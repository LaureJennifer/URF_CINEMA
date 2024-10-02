using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IUserReadWriteRepository
    {
        Task<RequestResult<Guid>> AddUserAsync(UserEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateUserAsync(UserEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteUserAsync(UserDeleteRequest request, CancellationToken cancellationToken);
    }
}
