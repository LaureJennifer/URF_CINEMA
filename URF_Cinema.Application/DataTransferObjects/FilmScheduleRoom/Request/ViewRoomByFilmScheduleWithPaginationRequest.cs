using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class ViewRoomByFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public Guid? FilmScheduleId { get; set; }
    }
}
