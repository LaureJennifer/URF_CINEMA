using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.RoomLayout.Request
{
    public class ViewRoomLayoutWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }

        public EntityStatus? Status { get; set; }
    }
}
