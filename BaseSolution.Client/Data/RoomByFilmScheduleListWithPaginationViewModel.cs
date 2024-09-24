using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.ValueObjects.Pagination;

namespace BaseSolution.Client.Data
{
    public class RoomByFilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }

    }
}
