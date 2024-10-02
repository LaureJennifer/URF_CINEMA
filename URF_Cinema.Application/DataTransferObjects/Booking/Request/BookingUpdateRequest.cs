using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Booking.Request
{
    public class BookingUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? FilmId { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public EntityStatus? SeatStatus { get; set; }
        public DateTimeOffset ExpiredTime { get; set; }

    }
}
