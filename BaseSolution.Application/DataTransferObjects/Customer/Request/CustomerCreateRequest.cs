using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Customer.Request
{
    public class CustomerCreateRequest
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string UrlImage { get; set; } = string.Empty;
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.UtcNow;
        public string ConfirmPassword { get; set; }
    }
}
