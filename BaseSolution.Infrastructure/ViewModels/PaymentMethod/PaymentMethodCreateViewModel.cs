using AutoMapper;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.PaymentMethod
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
