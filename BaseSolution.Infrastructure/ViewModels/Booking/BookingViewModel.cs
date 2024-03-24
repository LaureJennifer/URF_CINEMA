using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Booking
{
    public class BookingViewModel:ViewModelBase<Guid>
    {
        private readonly IBookingReadOnlyRepository _bookingReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public BookingViewModel(IBookingReadOnlyRepository bookingReadOnlyRepository, ILocalizationService localizationService)
        {
            _bookingReadOnlyRepository = bookingReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idBooking, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bookingReadOnlyRepository.GetBookingByIdAsync(idBooking, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the booking"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "booking")
                    }
                };
            }
        }
    }
}
