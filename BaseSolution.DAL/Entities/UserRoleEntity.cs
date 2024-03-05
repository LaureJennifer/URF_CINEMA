using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class UserRoleEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UserEntity UserEntity { get; set; }
        public RoleEntity RoleEntity { get; set; }
    }
}
