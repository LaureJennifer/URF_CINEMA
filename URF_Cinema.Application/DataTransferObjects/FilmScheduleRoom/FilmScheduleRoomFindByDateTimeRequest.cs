namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom
{
    public class FilmScheduleRoomFindByDateTimeRequest
    {
        public DateTimeOffset? ShowDate { get; set; }
        public DateTimeOffset? ShowTime { get; set; }
    }
}
