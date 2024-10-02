using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class RoomLayoutEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }
        public DateTimeOffset CreatedTime { get ; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<SeatEntity> Seats { get; set; }
        public virtual List<RoomEntity> Rooms { get; set; }
    }
}
