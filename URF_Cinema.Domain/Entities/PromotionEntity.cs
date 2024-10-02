using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class PromotionEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Conditions { get; set; }
        public float DiscountPercent { get; set; }
        public double DiscountAmount { get; set; }
        public double MaxApplicableAmount { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<CustomerPromotionEntity> CustomerPromotions { get; set; }

    }
}
