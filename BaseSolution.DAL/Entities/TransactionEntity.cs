using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class TransactionEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid BillId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public double Price { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public BillEntity BillEntity { get; set; }
        public PaymentMethodEntity PaymentMethodEntity { get; set; }
    }
}
