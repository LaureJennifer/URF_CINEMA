using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.DataTransferObjects.Transaction.Request;
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

namespace BaseSolution.Infrastructure.ViewModels.Transaction
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
