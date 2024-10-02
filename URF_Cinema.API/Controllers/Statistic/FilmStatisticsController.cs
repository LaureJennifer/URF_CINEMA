using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Infrastructure.ViewModels.Statistic.Film;

namespace URF_Cinema.API.Controllers.Statistic
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
