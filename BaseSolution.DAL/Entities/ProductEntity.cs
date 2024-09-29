using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<DepartmentProductEntity> DepartmentProducts { get; set; }
        public virtual List<BillDetailEntity> BillDetails { get; set; }

    }
}
