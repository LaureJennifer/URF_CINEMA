using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Department.Request
{
    public class DepartmentCreateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressCode { get; set; }
        public string AddressCodeFormat { get; set; }
        public string Address { get; set; }

        public EntityStatus Status { get; set; }
    }
}
