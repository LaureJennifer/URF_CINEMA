using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class TransactionEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid BillId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public double Price { get; set; }
        public string TransactionReferenceNumber { get; set; } // Số tham chiếu giao dịch
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual BillEntity Bill { get; set; }
        public virtual PaymentMethodEntity PaymentMethod { get; set; }
    }
}
