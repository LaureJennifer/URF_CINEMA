using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingReadOnlyRepository _bookingReadOnlyRepository;
        private readonly IBookingReadWriteRepository _bookingReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingReadOnlyRepository bookingReadOnlyRepository, IBookingReadWriteRepository bookingReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _bookingReadOnlyRepository = bookingReadOnlyRepository;
            _bookingReadWriteRepository = bookingReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        // GET api/<ExampleController>/5
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] ViewBookingWithPaginationRequest request, CancellationToken cancellationToken)
        //{
        //    BookingListWithPaginationViewModel vm = new(_bookingReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(request, cancellationToken);

        //    return Ok(vm);
        //}

        //// GET api/<ExampleController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        //{
        //    BookingViewModel vm = new(_bookingReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(id, cancellationToken);

        //    return Ok(vm);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(BookingCreateRequest request, CancellationToken cancellationToken)
        {
            BookingCreateViewModel vm = new(_bookingReadOnlyRepository, _bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BookingUpdateRequest request, CancellationToken cancellationToken)
        {
            BookingUpdateViewModel vm = new(_bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BookingDeleteRequest request, CancellationToken cancellationToken)
        {
            BookingDeleteViewModel vm = new(_bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
