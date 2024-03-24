using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Booking
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
