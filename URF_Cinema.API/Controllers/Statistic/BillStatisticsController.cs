using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Statistic.Bill;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers.Statistic
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
            if (vm.Success)
            {
                List<BillStatisticForMonthDto> result = (List<BillStatisticForMonthDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
        [HttpGet("BillStatisticForQuarter")]
        public async Task<IActionResult> GetBillStatisticForQuarter([FromQuery] BillStatisticRequest request, CancellationToken cancellationToken)
        {
            GetBillStatisticForQuarterViewModel vm = new(_billStatisticReadOnly, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            if (vm.Success)
            {
                List<BillStatisticForQuarterDto> result = (List<BillStatisticForQuarterDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
        [HttpGet("BillStatisticForYear")]
        public async Task<IActionResult> GetBillStatisticForYear([FromQuery] BillStatisticRequest request, CancellationToken cancellationToken)
        {
            GetBillStatisticForYearViewModel vm = new(_billStatisticReadOnly, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            if (vm.Success)
            {
                List<BillStatisticForYearDto> result = (List<BillStatisticForYearDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
    }
}
