using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Transaction
{
    public class TransactionListWithPaginationViewModel:ViewModelBase<ViewTransactionWithPaginationRequest>
    {
        private readonly ITransactionReadOnlyRepository _transactionReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public TransactionListWithPaginationViewModel(ITransactionReadOnlyRepository transactionReadOnlyRepository, ILocalizationService localizationService)
        {
            _transactionReadOnlyRepository = transactionReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewTransactionWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _transactionReadOnlyRepository.GetTransactionWithPaginationByAdminAsync(request, cancellationToken);

                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {

                Success = false;
                ErrorItems = new[]
                {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the list of transaction"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of transaction")
                    }
                };
            }
        }
    }
}
