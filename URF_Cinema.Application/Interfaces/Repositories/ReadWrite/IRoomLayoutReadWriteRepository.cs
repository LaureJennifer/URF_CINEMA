using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRoomLayoutReadWriteRepository
    {
        Task<RequestResult<Guid>> AddRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteRoomLayoutAsync(RoomLayoutDeleteRequest request, CancellationToken cancellationToken);

    }
}
