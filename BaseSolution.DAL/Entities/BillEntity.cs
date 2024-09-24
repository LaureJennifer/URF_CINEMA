using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class BillEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Code  { get;set;  }
        public string? Description { get; set; }
        public double TotalPrice { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual CustomerEntity Customer{ get; set; }
        public virtual DepartmentEntity Department { get; set; }
        public virtual List<BillDetailEntity> BillDetails { get; set; }
        public virtual List<TicketEntity> Tickets { get; set; }
        public virtual List<TransactionEntity> Transactions { get; set; }
    }
}
