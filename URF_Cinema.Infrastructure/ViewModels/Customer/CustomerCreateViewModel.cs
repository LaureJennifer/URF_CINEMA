using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Customer
{
    public class CustomerCreateViewModel : ViewModelBase<CustomerCreateRequest>
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly ICustomerReadWriteRepository _customerReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public CustomerCreateViewModel(ICustomerReadOnlyRepository customerReadOnlyRepository, ICustomerReadWriteRepository customerReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _customerReadWriteRepository = customerReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(CustomerCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _customerReadWriteRepository.AddCustomerAsync(_mapper.Map<CustomerEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _customerReadOnlyRepository.GetCustomerByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the customer"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "customer")
                    }
                };
            }
        }
    }
}
