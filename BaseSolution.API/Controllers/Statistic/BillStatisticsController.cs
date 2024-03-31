using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.Statistic.Bill;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers.Statistic
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatisticsController : ControllerBase
    {
        private readonly IBillStatisticReadOnlyRespository _billStatisticReadOnly;
        private readonly ILocalizationService _localizationService;

        public BillStatisticsController(IBillStatisticReadOnlyRespository billStatisticReadOnly, ILocalizationService localizationService)
        {
            _billStatisticReadOnly = billStatisticReadOnly;
            _localizationService = localizationService;
        }
        [HttpGet("BillStatisticForMonth")]
        public async Task<IActionResult> GetBillStatisticForMonth([FromQuery] BillStatisticRequest request, CancellationToken cancellationToken)
        {
            GetBillStatisticForMonthViewModel vm = new(_billStatisticReadOnly, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("BillStatisticForQuarter")]
        public async Task<IActionResult> GetBillStatisticForQuarter([FromQuery] BillStatisticRequest request, CancellationToken cancellationToken)
        {
            GetBillStatisticForQuarterViewModel vm = new(_billStatisticReadOnly, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            
            return Ok(vm);
        }
        [HttpGet("BillStatisticForYear")]
        public async Task<IActionResult> GetBillStatisticForYear([FromQuery] BillStatisticRequest request, CancellationToken cancellationToken)
        {
            GetBillStatisticForYearViewModel vm = new(_billStatisticReadOnly, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
