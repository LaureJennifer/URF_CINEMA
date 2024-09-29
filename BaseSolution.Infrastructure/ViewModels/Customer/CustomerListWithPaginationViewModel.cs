using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Customer
{
    public class CustomerListWithPaginationViewModel :  ViewModelBase<ViewCustomerWithPaginationRequest>
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public CustomerListWithPaginationViewModel(ICustomerReadOnlyRepository customerReadOnlyRepository, ILocalizationService localizationService)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewCustomerWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerReadOnlyRepository.GetCustomerWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of customer"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of customer")
                    }
                };
            }
        }
    }
}
