using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset StartTime { get; set; } // Thời gian bắt đầu làm việc
        public string EducationLevel { get; set; } // Trình độ học vấn
        public string UrlImage { get; set; }

        public string PassWord { get; set; }
        public EntityStatus Status { get; set; }
        public string Role { get; set; }
        public bool Deleted { get; set; }
    }
}
