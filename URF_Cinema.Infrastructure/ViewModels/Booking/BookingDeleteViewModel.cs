using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Booking
{
    public class BookingDeleteViewModel:ViewModelBase<BookingDeleteRequest>
    {
        private readonly IBookingReadWriteRepository _bookingReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BookingDeleteViewModel(IBookingReadWriteRepository bookingReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _bookingReadWriteRepository = bookingReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BookingDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bookingReadWriteRepository.DeleteBookingAsync(request, cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the booking"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "booking")
                    }
                };
            }
        }
    }
}
