using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.ValueObjects.Pagination;

namespace BaseSolution.BlazorServer.Data
{
    public class RoomByFilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }

    }
}
