using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Bill
{
    public class BillCreateViewModel:ViewModelBase<BillCreateRequest>
    {
        private readonly IBillReadOnlyRepository _billReadOnlyRepository;
        private readonly IBillReadWriteRepository _billReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public BillCreateViewModel(IBillReadOnlyRepository billReadOnlyRepository, IBillReadWriteRepository billReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _billReadOnlyRepository = billReadOnlyRepository;
            _billReadWriteRepository = billReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BillCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _billReadWriteRepository.AddBillAsync(_mapper.Map<BillEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _billReadOnlyRepository.GetBillByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
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
                        Error = _localizationService["Error occurred while getting the room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "room")
                    }
                };
            }
        }
    }
}
