using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
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
