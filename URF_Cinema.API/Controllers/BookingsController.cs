using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Infrastructure.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetListBookingByAdmin([FromQuery] ViewBookingWithPaginationRequest request, CancellationToken cancellationToken)
        {
            BookingListWithPaginationViewModel vm = new(_bookingReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);
            if (vm.Success)
            {
                PaginationResponse<BookingDto> result = (PaginationResponse<BookingDto>)vm.Data;
                return Ok(result);
            }
            return BadRequest(vm);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id, CancellationToken cancellationToken)
        {
            BookingViewModel vm = new(_bookingReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingCreateRequest request, CancellationToken cancellationToken)
        {
            BookingCreateViewModel vm = new(_bookingReadOnlyRepository, _bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(BookingUpdateRequest request, CancellationToken cancellationToken)
        {
            BookingUpdateViewModel vm = new(_bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(BookingDeleteRequest request, CancellationToken cancellationToken)
        {
            BookingDeleteViewModel vm = new(_bookingReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
