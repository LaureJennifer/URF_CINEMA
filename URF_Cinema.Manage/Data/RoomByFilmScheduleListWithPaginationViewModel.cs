using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data.ValueObjects.Pagination;

namespace URF_Cinema.Manage.Data
{
    public class RoomByFilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }

    }
}
