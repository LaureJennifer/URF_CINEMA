using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class BookingEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public Guid RoomId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTimeOffset ExpiredTime { get; set; }
        public EntityStatus SeatStatus { get; set; } = EntityStatus.Active;
        public virtual RoomEntity Room { get; set; }
        public virtual SeatEntity Seat { get; set; }
        public virtual CustomerEntity? Customer { get; set; }
        public virtual TicketEntity Ticket { get; set; }

    }
}
