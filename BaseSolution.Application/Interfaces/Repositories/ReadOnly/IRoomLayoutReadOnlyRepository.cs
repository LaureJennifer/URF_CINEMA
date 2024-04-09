using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.DataTransferObjects.Seat;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoomLayoutReadOnlyRepository
    {
        Task<RequestResult<RoomLayoutDto?>> GetRoomLayoutByIdAsync(Guid idRoomLayout, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoomLayoutDto>>> GetRoomLayoutWithPaginationByAdminAsync(
            ViewRoomLayoutWithPaginationRequest request, CancellationToken cancellationToken);

        Task<RequestResult<RoomLayoutDto>> GetSeatByNameAsync(string roomLayoutName, CancellationToken cancellationToken);

    }
}
