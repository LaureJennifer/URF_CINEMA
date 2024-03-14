using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IRoomReadOnlyRepository
    {
        Task<RequestResult<RoomDto?>> GetRoomByIdAsync(Guid idRoom, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<RoomDto>>> GetRoomWithPaginationByAdminAsync(
            ViewRoomWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
