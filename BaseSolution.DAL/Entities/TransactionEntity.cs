using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid BillId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public double Price { get; set; }
        public BillEntity BillEntity { get; set; }
        public PaymentMethodEntity PaymentMethodEntity { get; set; }
    }
}
