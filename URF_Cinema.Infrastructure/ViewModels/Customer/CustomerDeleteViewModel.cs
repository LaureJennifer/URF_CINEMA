using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Customer
{
    public class CustomerDeleteViewModel : ViewModelBase<CustomerDeleteRequest>
    {
        private readonly ICustomerReadWriteRepository _customerReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public CustomerDeleteViewModel(ICustomerReadWriteRepository customerReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _customerReadWriteRepository = customerReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerReadWriteRepository.DeleteCustomerAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the customer"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "customer")
                    }
                };
            }
        }
    }
}
