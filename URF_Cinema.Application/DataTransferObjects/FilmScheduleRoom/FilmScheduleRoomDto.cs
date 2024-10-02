using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom
{
    public class FilmScheduleRoomDto
    {
        public Guid Id { get; set; }

        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }
        public string RoomCode { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }

        public EntityStatus Status { get; set; }
    }
}
