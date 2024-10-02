using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Transaction
{
    public class TransactionUpdateViewModel : ViewModelBase<TransactionUpdateRequest>
    {
        private readonly ITransactionReadWriteRepository _transactionReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TransactionUpdateViewModel(ITransactionReadWriteRepository transactionReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _transactionReadWriteRepository = transactionReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(TransactionUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _transactionReadWriteRepository.UpdateTransactionAsync(_mapper.Map<TransactionEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the transaction"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "transaction")
                    }
                };
            }
        }
    }
}
