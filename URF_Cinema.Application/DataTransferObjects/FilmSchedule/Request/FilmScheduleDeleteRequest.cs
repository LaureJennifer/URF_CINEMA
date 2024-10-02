namespace URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request
{
    public class FilmScheduleDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
