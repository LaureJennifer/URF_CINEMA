using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Client.ValueObjects.Pagination;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Data.ValueObjects
{
    public class FilmScheduleRoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }
    }
}
