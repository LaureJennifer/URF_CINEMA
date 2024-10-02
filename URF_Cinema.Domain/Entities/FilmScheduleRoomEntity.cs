using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class FilmScheduleRoomEntity
    {
        public Guid Id { get; set; }
        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual RoomEntity Room { get; set; }
        public virtual FilmScheduleEntity FilmSchedule { get; set; }
    }
}
