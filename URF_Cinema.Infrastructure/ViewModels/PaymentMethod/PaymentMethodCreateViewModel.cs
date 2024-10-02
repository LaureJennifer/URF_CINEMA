using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.PaymentMethod
{
    public class PaymentMethodCreateViewModel : ViewModelBase<PaymentMethodCreateRequest>
    {
        private readonly IPaymentMethodReadOnlyRepository _paymentMethodReadOnlyRepository;
        private readonly IPaymentMethodReadWriteRepository _paymentMethodReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public PaymentMethodCreateViewModel(IPaymentMethodReadOnlyRepository paymentMethodReadOnlyRepository, IPaymentMethodReadWriteRepository paymentMethodReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _paymentMethodReadOnlyRepository = paymentMethodReadOnlyRepository;
            _paymentMethodReadWriteRepository = paymentMethodReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(PaymentMethodCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _paymentMethodReadWriteRepository.AddPaymentMethodAsync(_mapper.Map<PaymentMethodEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _paymentMethodReadOnlyRepository.GetPaymentMethodByIdAsync(createResult.Data, cancellationToken);

                    Data = createResult;
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
                        Error = _localizationService["Error occurred while getting the payment method"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "payment method")
                    }
                };
            }
        }
    }
}
