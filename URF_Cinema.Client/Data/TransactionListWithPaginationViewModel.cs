using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class TransactionListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<TransactionDto>? Data { get; set; }
    }
}
