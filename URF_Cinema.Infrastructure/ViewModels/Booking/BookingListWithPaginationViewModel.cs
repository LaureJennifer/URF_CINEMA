using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Booking
{
    public class BookingListWithPaginationViewModel : ViewModelBase<ViewBookingWithPaginationRequest>
    {
        private readonly IBookingReadOnlyRepository _bookingReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public BookingListWithPaginationViewModel(IBookingReadOnlyRepository bookingReadOnlyRepository, ILocalizationService localizationService)
        {
            _bookingReadOnlyRepository = bookingReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewBookingWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bookingReadOnlyRepository.GetBookingWithPaginationByAdminAsync(request, cancellationToken);

                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {

                Success = false;
                ErrorItems = new[]
                {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the list of booking"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of booking")
                    }
                };
            }
        }
    }
}
