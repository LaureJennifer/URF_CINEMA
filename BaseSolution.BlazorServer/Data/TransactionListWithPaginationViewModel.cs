using BaseSolution.Application.DataTransferObjects.Transaction;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class TransactionListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<TransactionDto>? Data { get; set; }
    }
}
