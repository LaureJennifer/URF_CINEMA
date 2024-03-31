using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class RoomLayoutListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoomLayoutDto>? Data { get; set; }
    }
}
