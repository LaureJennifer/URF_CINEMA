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

namespace BaseSolution.Infrastructure.ViewModels.Customer
{
    public class CustomerViewModel : ViewModelBase<Guid>
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public CustomerViewModel(ICustomerReadOnlyRepository customerReadOnlyRepository, ILocalizationService localizationService)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(Guid idUser, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerReadOnlyRepository.GetCustomerByIdAsync(idUser, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the user"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "user")
                    }
                };
            }
        }

    }
}
