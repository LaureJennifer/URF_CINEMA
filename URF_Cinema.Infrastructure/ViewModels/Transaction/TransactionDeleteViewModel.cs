using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Transaction
{
    public class TransactionDeleteViewModel :ViewModelBase<TransactionDeleteRequest>
    {
        private readonly ITransactionReadWriteRepository _transactionReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TransactionDeleteViewModel(ITransactionReadWriteRepository transactionReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _transactionReadWriteRepository = transactionReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(TransactionDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _transactionReadWriteRepository.DeleteTransactionAsync(request, cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "transaction")
                    }
                };
            }
        }
    }
}
