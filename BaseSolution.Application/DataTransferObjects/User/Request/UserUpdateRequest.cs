using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.User.Request
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UrlImage { get; set; }

        public string? PassWord { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
