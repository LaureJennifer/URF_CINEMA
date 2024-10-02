using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.PaymentMethod
{
    public class PaymentMethodViewModel : ViewModelBase<Guid>
    {
        private readonly IPaymentMethodReadOnlyRepository _paymentMethodReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public PaymentMethodViewModel(IPaymentMethodReadOnlyRepository paymentMethodReadOnlyRepository, ILocalizationService localizationService)
        {
            _paymentMethodReadOnlyRepository = paymentMethodReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idPaymentMethod, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _paymentMethodReadOnlyRepository.GetPaymentMethodByIdAsync(idPaymentMethod, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the payment method"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "payment method")
                    }
                };
            }
        }
    }
}
