using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmSchedule
{
    public class FilmScheduleDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public EntityStatus Status { get; set; }
    }
}
