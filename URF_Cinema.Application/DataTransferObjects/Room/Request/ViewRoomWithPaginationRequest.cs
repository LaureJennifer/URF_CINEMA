using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Room.Request
{
    public class ViewRoomWithPaginationRequest : PaginationRequest
    {
        public Guid? DepartmentId { get; set; }
        public string? RoomLayoutName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Code { get; set; }

    }
}
