using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Bill
{
    public class BillUpdateViewModel:ViewModelBase<BillUpdateRequest>
    {
        private readonly IBillReadWriteRepository _billReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public BillUpdateViewModel(IBillReadWriteRepository billReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _billReadWriteRepository = billReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BillUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billReadWriteRepository.UpdateBillAsync(_mapper.Map<BillEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the bill"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "bill")
                    }
                };
            }
        }
    }
}
