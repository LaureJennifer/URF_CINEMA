namespace URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request
{
    public class FilmScheduleCreateRequest
    {
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
    }
}
