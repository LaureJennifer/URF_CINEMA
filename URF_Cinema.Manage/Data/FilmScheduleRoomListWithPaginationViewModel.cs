using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Manage.Data.ValueObjects.Pagination;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Data.ValueObjects
{
    public class FilmScheduleRoomListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleRoomDto>? Data { get; set; }
    }
}
