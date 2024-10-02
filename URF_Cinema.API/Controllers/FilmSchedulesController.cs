using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.FilmSchedule;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
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
        public async Task<IActionResult> DeleteFilmSchedule([FromQuery]FilmScheduleDeleteRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleDeleteViewModel vm = new(_filmScheduleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
