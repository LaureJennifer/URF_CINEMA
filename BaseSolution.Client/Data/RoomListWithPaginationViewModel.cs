using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class RoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoomDto>? Data { get; set; }
    }
}
