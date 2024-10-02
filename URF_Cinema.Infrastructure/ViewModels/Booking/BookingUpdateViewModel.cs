using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Booking
{
    public class BookingUpdateViewModel:ViewModelBase<BookingUpdateRequest>
    {
        private readonly IBookingReadWriteRepository _bookingReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BookingUpdateViewModel(IBookingReadWriteRepository bookingReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _bookingReadWriteRepository = bookingReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BookingUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bookingReadWriteRepository.UpdateBookingAsync(_mapper.Map<BookingEntity>(request), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "booking")
                    }
                };
            }
        }
    }
}
