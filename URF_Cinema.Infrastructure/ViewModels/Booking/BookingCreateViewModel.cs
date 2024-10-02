using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Booking
{
    public class BookingCreateViewModel: ViewModelBase<BookingCreateRequest>
    {
        private readonly IBookingReadOnlyRepository _bookingReadOnlyRepository;
        private readonly IBookingReadWriteRepository _bookingReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BookingCreateViewModel(IBookingReadOnlyRepository bookingReadOnlyRepository, IBookingReadWriteRepository bookingReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _bookingReadOnlyRepository = bookingReadOnlyRepository;
            _bookingReadWriteRepository = bookingReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BookingCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _bookingReadWriteRepository.AddBookingAsync(_mapper.Map<BookingEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _bookingReadOnlyRepository.GetBookingByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }

                Success = createResult.Success;
                ErrorItems = createResult.Errors;
                Message = createResult.Message;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the booking"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "booking")
                    }
                };
            }
        }
    }
}
