using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketStatisticReadOnlyRespository
    {
        Task<RequestResult<List<TicketStatisticForMonthDto>>> GetTicketStasticForMonthAsync(
        TicketStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<TicketStatisticForQuarterDto>>> GetTicketStasticForQuarterAsync(
        TicketStatisticRequest request, CancellationToken cancellationToken);
    }
}
