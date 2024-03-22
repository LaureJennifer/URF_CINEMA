using AutoMapper;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.PaymentMethod
{
    public class PaymentMethodDeleteViewModel: ViewModelBase<PaymentMethodDeleteRequest>
    {
        private readonly IPaymentMethodReadWriteRepository _paymentMethodReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public PaymentMethodDeleteViewModel(IPaymentMethodReadWriteRepository paymentMethodReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _paymentMethodReadWriteRepository = paymentMethodReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(PaymentMethodDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _paymentMethodReadWriteRepository.DeletePaymentMethodAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the payment method"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "payment method")
                    }
                };
            }
        }
    }
}
