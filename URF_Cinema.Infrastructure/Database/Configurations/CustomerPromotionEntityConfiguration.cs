using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class CustomerPromotionEntityConfiguration : IEntityTypeConfiguration<CustomerPromotionEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerPromotionEntity> builder)
        {
            builder.ToTable("CustomerPromotion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Customer).WithMany(x => x.CustomerPromotions).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Promotion).WithMany(x => x.CustomerPromotions).HasForeignKey(x => x.PromotionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
