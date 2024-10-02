using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Bill
{
    public class BillDeleteViewModel:ViewModelBase<BillDeleteRequest>
    {
        private readonly IBillReadWriteRepository _billReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BillDeleteViewModel(IBillReadWriteRepository billReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _billReadWriteRepository = billReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BillDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billReadWriteRepository.DeleteBillAsync(request, cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "bill")
                    }
                };
            }
        }
    }
}
