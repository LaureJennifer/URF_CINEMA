using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Transaction.Request
{
    public class TransactionCreateRequest
    {
        public Guid PaymentMethodId { get; set; }
        public Guid BillId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public double Price { get; set; }
        public EntityStatus Status { get; set; }
    }
}
