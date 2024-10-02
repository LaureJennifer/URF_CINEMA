using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Transaction.Request
{
    public class ViewTransactionWithPaginationRequest:PaginationRequest
    {
        public Guid? BillId { get; set; }
        public DateTimeOffset? TransactionDate { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
