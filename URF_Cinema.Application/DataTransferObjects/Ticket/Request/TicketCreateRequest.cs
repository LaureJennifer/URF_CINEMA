namespace URF_Cinema.Application.DataTransferObjects.Ticket.Request
{
    public class TicketCreateRequest
    {
        public Guid BillId { get; set; }
        public Guid FilmId { get; set; }
        public Guid BookingId { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }

    }
}
