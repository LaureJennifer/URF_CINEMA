using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Transaction.Request
{
    public class ViewTransactionWithPaginationRequest:PaginationRequest
    {
        public Guid? BillId { get; set; }
        public DateTimeOffset? TransactionDate { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
