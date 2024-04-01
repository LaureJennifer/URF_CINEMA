using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class BillEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public CustomerEntity CustomerEntity { get; set; }
        public DepartmentEntity DepartmentEntity { get; set; }

        public List<TransactionEntity> Transactions { get; set; }
        public List<TicketEntity> Tickets { get; set; }
    }
}
