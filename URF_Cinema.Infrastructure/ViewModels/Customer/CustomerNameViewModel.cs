using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using static URF_Cinema.Application.ValueObjects.Common.LocalizationString;

namespace URF_Cinema.Infrastructure.ViewModels.Customer
{
    public class CustomerNameViewModel : ViewModelBase<string>
    {
        public readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public CustomerNameViewModel(ICustomerReadOnlyRepository customerReadOnlyRepository, ILocalizationService localizationService)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _localizationService = localizationService;
        }

        public override async Task HandleAsync(string data, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerReadOnlyRepository.GetCustomerByNameAsync(data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the Customer"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "Customer")
                    }
                };
            }
        }
    }
}
