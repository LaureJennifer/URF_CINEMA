using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? UrlImage { get; set; }
        public string? IdentificationNumber { get; set; } = string.Empty;
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public double TotalSpent { get; set; } // Tổng chi tiêu
        public string? CustomerType { get; set; } // Loại khách  hàng (Regular,Vip,Platinum...)
        public int TotalLoyaltyPoints { get; set; } // Tổng điểm của khách hàng
        public DateTimeOffset LoyaltyPointsExpiry { get; set; } // Thời hạn của điểm
        public EntityStatus Status { get; set; } = EntityStatus.Active;

    }
}
