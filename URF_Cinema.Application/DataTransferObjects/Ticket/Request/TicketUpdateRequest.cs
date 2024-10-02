using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Ticket.Request
{
    public class TicketUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? BillId { get; set; }
        public Guid? FilmId { get; set; }
        public Guid? BookingId { get; set; }
        public string? Code { get; set; }
        public EntityStatus? Status { get; set; }
       
    }
}
