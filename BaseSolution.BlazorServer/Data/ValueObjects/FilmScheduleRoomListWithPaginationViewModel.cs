using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.BlazorServer.ValueObjects.Pagination;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data.ValueObjects
{
    public class FilmScheduleRoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }
    }
}
