using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.Statistic;
using BaseSolution.Infrastructure.ViewModels.Statistic.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers.Statistic
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatisticsController : ControllerBase
    {
        private readonly ITicketStatisticReadOnlyRespository _ticketStatisticReadOnlyRespository;
        private readonly ILocalizationService _localizationService;

        public TicketStatisticsController(ITicketStatisticReadOnlyRespository ticketStatisticReadOnlyRespository, ILocalizationService localizationService)
        {
            _ticketStatisticReadOnlyRespository = ticketStatisticReadOnlyRespository;
            _localizationService = localizationService;
        }

        [HttpGet("BillStatisticForMonth")]
        public async Task<IActionResult> GetBillStatisticForMonth([FromQuery] TicketStatisticRequest request, CancellationToken cancellationToken)
        {
            GetTicketStatisticForMonthViewModel vm = new(_ticketStatisticReadOnlyRespository, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("BillStatisticForQuarter")]
        public async Task<IActionResult> GetBillStatisticForQuarter([FromQuery] TicketStatisticRequest request, CancellationToken cancellationToken)
        {
            GetTicketStatisticForQuarterViewModel vm = new(_ticketStatisticReadOnlyRespository, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }       
       
    }
}
