using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class TicketEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set;}
        public Guid BookingId { get; set;}
        public Guid FilmId { get; set;}
        public string Code {  get; set;}
        public string? Description { get; set; }
        public double Price { get; set;}
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual BillEntity Bill { get; set; }
        public virtual BookingEntity Booking { get; set; }
        public virtual FilmEntity Film { get; set; }
    }
}
