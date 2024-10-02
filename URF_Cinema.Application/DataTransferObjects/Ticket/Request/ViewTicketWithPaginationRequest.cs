using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Ticket.Request
{
    public class ViewTicketWithPaginationRequest:PaginationRequest
    {
        public Guid? BillId { get; set; }
        public string? FilmName { get; set; }
        public string? Code { get; set; }
        
    }
}
