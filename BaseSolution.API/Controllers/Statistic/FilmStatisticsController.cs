using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.Statistic.Bill;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Infrastructure.ViewModels.Statistic.Film;

namespace BaseSolution.API.Controllers.Statistic
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStatisticsController : ControllerBase
    {
        private readonly IFilmStatisticReadOnlyRespository _filmStatisticReadOnlyRespository;
        private readonly ILocalizationService _localizationService;

        public FilmStatisticsController(IFilmStatisticReadOnlyRespository filmStatisticReadOnlyRespository, ILocalizationService localizationService)
        {
            _filmStatisticReadOnlyRespository = filmStatisticReadOnlyRespository;
            _localizationService = localizationService;
        }

        [HttpGet("FilmStatisticForMonth")]
        public async Task<IActionResult> GetFilmStatisticForMonth([FromQuery] FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            GetFilmStatisticForMonthViewModel vm = new(_filmStatisticReadOnlyRespository, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            if (vm.Success)
            {
                List<FilmStatisticForMonthDto> result = (List<FilmStatisticForMonthDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
        [HttpGet("FilmStatisticForQuarter")]
        public async Task<IActionResult> GetFilmStatisticForQuarter([FromQuery] FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            GetFilmStatisticForQuarterViewModel vm = new(_filmStatisticReadOnlyRespository, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            if (vm.Success)
            {
                List<FilmStatisticForQuarterDto> result = (List<FilmStatisticForQuarterDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
        [HttpGet("FilmStatisticForYear")]
        public async Task<IActionResult> GetFilmStatisticForYear([FromQuery] FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            GetFilmStatisticForYearViewModel vm = new(_filmStatisticReadOnlyRespository, _localizationService);
            await vm.HandleAsync(request, cancellationToken);

            if (vm.Success)
            {
                List<FilmStatisticForYearDto> result = (List<FilmStatisticForYearDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
        }
    }
}
