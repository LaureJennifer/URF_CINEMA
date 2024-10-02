using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Transaction
{
    public class TransactionCreateViewModel :ViewModelBase<TransactionCreateRequest>
    {
        private readonly ITransactionReadOnlyRepository _transactionReadOnlyRepository;
        private readonly ITransactionReadWriteRepository _transactionReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public TransactionCreateViewModel(ITransactionReadOnlyRepository transactionReadOnlyRepository, ITransactionReadWriteRepository transactionReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _transactionReadOnlyRepository = transactionReadOnlyRepository;
            _transactionReadWriteRepository = transactionReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(TransactionCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _transactionReadWriteRepository.AddTransactionAsync(_mapper.Map<TransactionEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _transactionReadOnlyRepository.GetTransactionByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the transaction"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "transaction")
                    }
                };
            }
        }
    }
}
