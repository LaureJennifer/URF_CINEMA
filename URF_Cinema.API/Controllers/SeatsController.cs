using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatsController(ISeatReadOnlyRepository seatReadOnlyRepository, ISeatReadWriteRepository seatReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _seatReadWriteRepository = seatReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListSeatByAdmin([FromQuery] ViewSeatWithPaginationRequest request, CancellationToken cancellationToken)
        {
            SeatListWithPaginationViewModel vm = new(_seatReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(Guid id, CancellationToken cancellationToken)
        {
            SeatViewModel vm = new(_seatReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }
        [HttpGet("code")]
        public async Task<IActionResult> GetSeatByCode(string code, CancellationToken cancellationToken)
        {
            SeatByCodeViewModel vm = new(_seatReadOnlyRepository, _localizationService);

            await vm.HandleAsync(code, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat(SeatCreateRequest request, CancellationToken cancellationToken)
        {
            SeatCreateViewModel vm = new(_seatReadOnlyRepository, _seatReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
        [HttpPost("CreateRangeSeat")]
        public async Task<IActionResult> CreateRangeSeat([FromBody]List<SeatCreateRangeRequest> request, CancellationToken cancellationToken)
        {
            SeatCreateRangeViewModel vm = new(_seatReadWriteRepository, _seatReadOnlyRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeat(SeatUpdateRequest request, CancellationToken cancellationToken)
        {
            SeatUpdateViewModel vm = new(_seatReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeat([FromQuery]SeatDeleteRequest request, CancellationToken cancellationToken)
        {
            SeatDeleteViewModel vm = new(_seatReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
