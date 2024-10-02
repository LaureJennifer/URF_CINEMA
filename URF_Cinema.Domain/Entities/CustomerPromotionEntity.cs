namespace URF_Cinema.Domain.Entities
{
    public class CustomerPromotionEntity
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? PromotionId { get; set; }
        public CustomerEntity Customer { get; set; }
        public PromotionEntity Promotion { get; set; }
    }
}
