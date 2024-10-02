using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class RoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoomDto>? Data { get; set; }
    }
}
