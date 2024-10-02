using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
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
