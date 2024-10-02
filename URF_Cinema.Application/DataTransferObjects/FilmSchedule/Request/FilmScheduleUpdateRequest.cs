using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request
{
    public class FilmScheduleUpdateRequest
    {
        public Guid Id { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
