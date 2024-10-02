using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Client.Data.ValueObjects.Pagination;
using URF_Cinema.Client.Data.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class FilmScheduleRoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }
    }
}
