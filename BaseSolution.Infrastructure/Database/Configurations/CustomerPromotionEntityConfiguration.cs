using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class CustomerPromotionEntityConfiguration : IEntityTypeConfiguration<CustomerPromotionEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerPromotionEntity> builder)
        {
            builder.ToTable("CustomerPromotion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Customer).WithMany(x => x.CustomerPromotions).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Promotion).WithMany(x => x.CustomerPromotions).HasForeignKey(x => x.PromotionId);
        }
    }
}
