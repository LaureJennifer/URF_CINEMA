using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface ITicketReadWriteRepository
    {
        Task<RequestResult<Guid>> AddTicketAsync(TicketEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateTicketAsync(TicketEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteTicketAsync(TicketDeleteRequest request, CancellationToken cancellationToken);
    }
}
