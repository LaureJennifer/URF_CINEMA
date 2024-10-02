using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.RoomLayout;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomLayoutsController : ControllerBase
    {
        private readonly IRoomLayoutReadOnlyRepository _roomLayoutReadOnlyRepository;
        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoomLayoutsController(IRoomLayoutReadOnlyRepository roomLayoutReadOnlyRepository, IRoomLayoutReadWriteRepository roomLayoutReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roomLayoutReadOnlyRepository = roomLayoutReadOnlyRepository;
            _roomLayoutReadWriteRepository = roomLayoutReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListRoomLayoutByAdmin([FromQuery] ViewRoomLayoutWithPaginationRequest request, CancellationToken cancellationToken)
        {
            RoomLayoutListWithPaginationViewModel vm = new(_roomLayoutReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomLayoutById(Guid id, CancellationToken cancellationToken)
        {
            RoomLayoutViewModel vm = new(_roomLayoutReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("name")]
        public async Task<IActionResult> GetRoomLayoutByName(string RoomLayoutName, CancellationToken cancellationToken)
        {
            RoomlLayoutByNameViewModel vm = new(_roomLayoutReadOnlyRepository, _localizationService);

            await vm.HandleAsync(RoomLayoutName, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomLayout(RoomLayoutCreateRequest request, CancellationToken cancellationToken)
        {
            RoomLayoutCreateViewModel vm = new(_roomLayoutReadOnlyRepository, _roomLayoutReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomLayout(RoomLayoutUpdateRequest request, CancellationToken cancellationToken)
        {
            RoomLayoutUpdateViewModel vm = new(_roomLayoutReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomLayout([FromQuery]RoomLayoutDeleteRequest request, CancellationToken cancellationToken)
        {
            RoomLayoutDeleteViewModel vm = new(_roomLayoutReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
