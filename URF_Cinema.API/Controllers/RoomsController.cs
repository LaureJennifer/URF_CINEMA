using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomReadOnlyRepository _roomReadOnlyRepository;
        private readonly IRoomReadWriteRepository _roomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomReadOnlyRepository roomReadOnlyRepository, IRoomReadWriteRepository roomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomReadOnlyRepository = roomReadOnlyRepository;
            _roomReadWriteRepository = roomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetListRoomByAdmin([FromQuery] ViewRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            RoomListWithPaginationViewModel vm = new(_roomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id, CancellationToken cancellationToken)
        {
            RoomViewModel vm = new(_roomReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomCreateRequest request, CancellationToken cancellationToken)
        {
            RoomCreateViewModel vm = new(_roomReadOnlyRepository, _roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(RoomUpdateRequest request, CancellationToken cancellationToken)
        {
            RoomUpdateViewModel vm = new(_roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoom([FromQuery] RoomDeleteRequest request, CancellationToken cancellationToken)
        {
            RoomDeleteViewModel vm = new(_roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
