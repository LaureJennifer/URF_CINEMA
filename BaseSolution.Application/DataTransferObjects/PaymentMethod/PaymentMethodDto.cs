using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.PaymentMethod
{
    public class PaymentMethodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PaymentContent { get; set; } = string.Empty;
        public string PaymentCurrency { get; set; } = string.Empty;
        public Guid PaymentRefId { get; set; }
        public decimal? RequiredAmount { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public DateTime? ExpireDate { get; set; }
        public string? PaymentLanguage { get; set; } = string.Empty;
        public Guid? MerchantId { get; set; }
        public string? PaymentDestinationId { get; set; } = string.Empty;
        public string? PaymentStatus { get; set; } = string.Empty;
        public decimal? PaidAmount { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
