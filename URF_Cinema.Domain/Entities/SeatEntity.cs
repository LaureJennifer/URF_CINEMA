using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class SeatEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid RoomLayoutId { get; set; }
        public string? Description { get; set; }
        public string Code {  get; set; }
        public string Row { get; set; }
        public int SeatColumn { get; set; }
        public EntityTypeSeat Type { get; set; }
        public double Price { get; set; }  
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual RoomLayoutEntity RoomLayout { get; set; }
        public virtual List<BookingEntity> Bookings { get; set; }
    }
}
