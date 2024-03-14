using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class CustomerEntity : EntityBase 
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UrlImage { get; set; }
        public string UserName { get; set; }

        public string PassWord { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public List<BillEntity> Bills { get; set; }
    }
}
