using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketReadOnlyRepository
    {
        Task<RequestResult<TicketDto?>> GetTicketByIdAsync(Guid idTicket, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<TicketDto>>> GetTicketWithPaginationByAdminAsync(
            ViewTicketWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
