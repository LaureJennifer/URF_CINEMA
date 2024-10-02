using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.DataTransferObjects.Ticket;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketStatisticReadOnlyRespository
    {
        Task<RequestResult<List<TicketStatisticForMonthDto>>> GetTicketStasticForMonthAsync(
        TicketStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<TicketStatisticForQuarterDto>>> GetTicketStasticForQuarterAsync(
        TicketStatisticRequest request, CancellationToken cancellationToken);
    }
}
