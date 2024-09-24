using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class TicketEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set;}
        public Guid BookingId { get; set;}
        public string Code {  get; set;}
        public string? Description { get; set; }
        public double Price { get; set;}
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual BillEntity Bill { get; set; }
        public virtual BookingEntity Booking { get; set; }
    }
}
