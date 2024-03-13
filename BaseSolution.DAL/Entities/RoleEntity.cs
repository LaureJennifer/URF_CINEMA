using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoleEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public List<UserEntity> Users { get; set; }
        public List<CustomerEntity> Customers { get; set; }
    }
}
