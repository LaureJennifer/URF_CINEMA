using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.PaymentMethod
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
