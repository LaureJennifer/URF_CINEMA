using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Customer
{
    public class CustomerResetViewModel : ViewModelBase<ResetPassword>
    {
        private readonly ICustomerReadWriteRepository _customerReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public CustomerResetViewModel(ICustomerReadWriteRepository customerReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _customerReadWriteRepository = customerReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(ResetPassword data, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerReadWriteRepository.ResetPasswordCustomerAsync(_mapper.Map<CustomerEntity>(data), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "customer")
                    }
                };
            }
        }
    }
}
