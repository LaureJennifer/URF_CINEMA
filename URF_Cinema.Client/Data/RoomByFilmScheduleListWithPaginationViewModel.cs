using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data.ValueObjects.Pagination;

namespace URF_Cinema.Client.Data
{
    public class RoomByFilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }

    }
}
