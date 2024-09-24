using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class PaymentMethodEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<TransactionEntity> Transactions { get; set; }
    }
}
