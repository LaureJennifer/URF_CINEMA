using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Booking
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public Guid RoomId { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
        public string SeatCode { get; set; }
        public string RoomCode { get; set; }
        public EntityStatus SeatStatus { get; set; }

        public DateTimeOffset ExpiredTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
