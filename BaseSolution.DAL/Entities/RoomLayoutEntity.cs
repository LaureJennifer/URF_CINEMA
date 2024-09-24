using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
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
