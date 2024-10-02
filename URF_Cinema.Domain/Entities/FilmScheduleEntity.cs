using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class FilmScheduleEntity : EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public string? Description { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<FilmDetailEntity> FilmDetails { get; set; }
        public virtual List<FilmScheduleRoomEntity> FilmScheduleRooms { get; set; }
        public virtual List<BookingEntity> Bookings { get; set; }

    }
}
