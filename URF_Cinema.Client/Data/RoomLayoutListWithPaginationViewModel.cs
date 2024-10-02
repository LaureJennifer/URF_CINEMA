using URF_Cinema.Application.DataTransferObjects.RoomLayout;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class RoomLayoutListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoomLayoutDto>? Data { get; set; }
    }
}
