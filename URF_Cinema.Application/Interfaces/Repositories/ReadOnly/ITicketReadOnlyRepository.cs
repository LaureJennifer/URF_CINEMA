using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Ticket;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketReadOnlyRepository
    {
        Task<RequestResult<TicketDto?>> GetTicketByIdAsync(Guid idTicket, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<TicketDto>>> GetTicketWithPaginationByAdminAsync(
            ViewTicketWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
