using AutoMapper;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.ViewModels.FilmSchedule;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmSchedulesController : ControllerBase
    {
        private readonly IFilmScheduleReadOnlyRepository _filmScheduleReadOnlyRepository;
        private readonly IFilmScheduleReadWriteRepository _filmScheduleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmSchedulesController(IFilmScheduleReadOnlyRepository filmScheduleReadOnlyRepository, IFilmScheduleReadWriteRepository filmScheduleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleReadOnlyRepository = filmScheduleReadOnlyRepository;
            _filmScheduleReadWriteRepository = filmScheduleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListFilmScheduleByAdmin([FromQuery] ViewFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleListWithPaginationViewModel vm = new(_filmScheduleReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmScheduleById(Guid id, CancellationToken cancellationToken)
        {
            FilmScheduleViewModel vm = new(_filmScheduleReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmSchedule(FilmScheduleCreateRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleCreateViewModel vm = new(_filmScheduleReadOnlyRepository, _filmScheduleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilmSchedule(FilmScheduleUpdateRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleUpdateViewModel vm = new(_filmScheduleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFilmSchedule(FilmScheduleDeleteRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleDeleteViewModel vm = new(_filmScheduleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
