using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.FilmScheduleRoom;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmScheduleRoomsController : ControllerBase
    {
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly IFilmScheduleRoomReadWriteRepository _filmScheduleRoomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleRoomsController(IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, IFilmScheduleRoomReadWriteRepository filmScheduleRoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _filmScheduleRoomReadWriteRepository = filmScheduleRoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListFilmScheduleRoomByAdmin([FromQuery] ViewFilmScheduleRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomListWithPaginationViewModel vm = new(_filmScheduleRoomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("getRoomIdByFilmSchedule")]
        public async Task<IActionResult> GetRoomByFilmSchedule([FromQuery] ViewRoomByFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            RoomByFilmScheduleListWithPaginationViewModel vm = new(_filmScheduleRoomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmScheduleRoomById(Guid id, CancellationToken cancellationToken)
        {
            FilmScheduleRoomViewModel vm = new(_filmScheduleRoomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }
        // Find by showDate && showTime
        [HttpGet("showDateTime")]
        public async Task<IActionResult> GetFilmScheduleRoomByShowDateTime([FromQuery]FilmScheduleRoomFindByDateTimeRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomByTimeViewModel vm = new(_filmScheduleRoomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPost("CreateRangeFilmScheduleRoom")]
        public async Task<IActionResult> CreateRangeFilmScheduleRoom([FromBody] List<FilmScheduleRoomCreateRangeRequest> request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomCreateRangeViewModel vm = new(_filmScheduleRoomReadWriteRepository, _filmScheduleRoomReadOnlyRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmScheduleRoom(FilmScheduleRoomCreateRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomCreateViewModel vm = new(_filmScheduleRoomReadOnlyRepository, _filmScheduleRoomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilmScheduleRoom(FilmScheduleRoomUpdateRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomUpdateRoomViewModel vm = new(_filmScheduleRoomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFilmScheduleRoom([FromQuery]FilmScheduleRoomDeleteRequest request, CancellationToken cancellationToken)
        {
            FilmScheduleRoomDeleteRoomViewModel vm = new(_filmScheduleRoomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
