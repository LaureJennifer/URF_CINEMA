using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Role
{
    public class RoleDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
