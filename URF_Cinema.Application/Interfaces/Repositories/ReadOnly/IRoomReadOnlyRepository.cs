using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoomReadOnlyRepository
    {
        Task<RequestResult<RoomDto?>> GetRoomByIdAsync(Guid idRoom, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoomDto>>> GetRoomWithPaginationByAdminAsync(
            ViewRoomWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
