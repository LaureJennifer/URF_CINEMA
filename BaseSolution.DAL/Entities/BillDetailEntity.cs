using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class BillDetailEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid? ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual BillEntity Bill { get; set; }
        public virtual ProductEntity Product { get;set; }
    }
}
