using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Statistic.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers.Statistic
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
