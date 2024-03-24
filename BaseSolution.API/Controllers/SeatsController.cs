using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Department;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateSeat(SeatCreateRequest request, CancellationToken cancellationToken)
        {
            SeatCreateViewModel vm = new(_seatReadOnlyRepository, _seatReadWriteRepository, _localizationService, _mapper);

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
        public async Task<IActionResult> DeleteSeat(SeatDeleteRequest request, CancellationToken cancellationToken)
        {
            SeatDeleteViewModel vm = new(_seatReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
