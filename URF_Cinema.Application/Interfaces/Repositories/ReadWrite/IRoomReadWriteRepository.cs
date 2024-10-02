using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRoomReadWriteRepository
    {
        Task<RequestResult<Guid>> AddRoomAsync(RoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateRoomAsync(RoomEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteRoomAsync(RoomDeleteRequest request, CancellationToken cancellationToken);
    }
}
