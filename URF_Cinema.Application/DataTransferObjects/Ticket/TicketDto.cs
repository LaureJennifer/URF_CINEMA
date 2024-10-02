using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Ticket
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid BookingId { get; set; }
        public Guid FilmId { get; set; }
        public string DepartmentName { get; set; }
        public string FilmName { get; set; }
        public string SeatCode { get; set; }
        public string RoomCode { get; set; }
        public double Price { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public string Code { get; set; }
        public EntityStatus Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }

    }
}
