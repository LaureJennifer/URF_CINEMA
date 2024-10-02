using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class ViewFilmScheduleRoomWithPaginationRequest : PaginationRequest
    {
        public Guid? RoomId { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public string? RoomCode { get; set; }
        public DateTimeOffset? ShowDate { get; set; }
        public DateTimeOffset? ShowTime { get; set; }
    }
}
