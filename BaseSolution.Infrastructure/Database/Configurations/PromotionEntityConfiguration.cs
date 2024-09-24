using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class PromotionEntityConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
        public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {
            builder.ToTable("Promotion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.DiscountPercent).IsRequired();
            builder.Property(x => x.Conditions).IsRequired();
            builder.Property(x => x.DiscountAmount).IsRequired();
            builder.Property(x => x.MaxApplicableAmount).IsRequired();
        }
    }
}
