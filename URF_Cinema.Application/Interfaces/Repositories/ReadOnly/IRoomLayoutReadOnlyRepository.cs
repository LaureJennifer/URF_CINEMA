using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.RoomLayout;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoomLayoutReadOnlyRepository
    {
        Task<RequestResult<RoomLayoutDto?>> GetRoomLayoutByIdAsync(Guid idRoomLayout, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoomLayoutDto>>> GetRoomLayoutWithPaginationByAdminAsync(
            ViewRoomLayoutWithPaginationRequest request, CancellationToken cancellationToken);

        Task<RequestResult<RoomLayoutDto>> GetSeatByNameAsync(string roomLayoutName, CancellationToken cancellationToken);

    }
}
