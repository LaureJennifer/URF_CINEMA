using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class BillEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public double Price { get; set; }
        public int TicketQuantity {  get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }

        public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
        public CustomerEntity CustomerEntity { get; set; }
        public List<TicketEntity> Tickets { get; set; }
    }
}
