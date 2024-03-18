using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Room;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
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
        // GET api/<ExampleController>/5
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] ViewRoomWithPaginationRequest request, CancellationToken cancellationToken)
        //{
        //    RoomListWithPaginationViewModel vm = new(_roomReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(request, cancellationToken);

        //    return Ok(vm);
        //}

        //// GET api/<ExampleController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        //{
        //    RoomViewModel vm = new(_roomReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(id, cancellationToken);

        //    return Ok(vm);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(RoomCreateRequest request, CancellationToken cancellationToken)
        {
            RoomCreateViewModel vm = new(_roomReadOnlyRepository, _roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RoomUpdateRequest request, CancellationToken cancellationToken)
        {
            RoomUpdateViewModel vm = new(_roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RoomDeleteRequest request, CancellationToken cancellationToken)
        {
            RoomDeleteViewModel vm = new(_roomReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
