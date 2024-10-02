using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.PaymentMethod
{
    public class PaymentMethodListWithPaginationViewModel:ViewModelBase<ViewPaymentMethodWithPaginationRequest>
    {
        private readonly IPaymentMethodReadOnlyRepository _paymentMethodReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public PaymentMethodListWithPaginationViewModel(IPaymentMethodReadOnlyRepository paymentMethodReadOnlyRepository, ILocalizationService localizationService)
        {
            _paymentMethodReadOnlyRepository = paymentMethodReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _paymentMethodReadOnlyRepository.GetPaymentMethodWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of payment method"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of payment method")
                    }
                };
            }
        }
    }
}
