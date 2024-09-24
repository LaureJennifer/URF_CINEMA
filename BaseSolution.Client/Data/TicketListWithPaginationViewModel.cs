using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class TicketListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<TicketDto>? Data { get; set; }
    }
}
