namespace URF_Cinema.Application.DataTransferObjects.Ticket.Request
{
    public class TicketDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
