using URF_Cinema.Application.DataTransferObjects.Ticket;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class TicketListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<TicketDto>? Data { get; set; }
    }
}
