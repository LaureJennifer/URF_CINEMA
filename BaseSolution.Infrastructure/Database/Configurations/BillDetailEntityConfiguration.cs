using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class BillDetailEntityConfiguration : IEntityTypeConfiguration<BillDetailEntity>
    {
        public void Configure(EntityTypeBuilder<BillDetailEntity> builder)
        {
            builder.ToTable("BillDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Product).WithMany(x => x.BillDetails).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetails).HasForeignKey(x => x.BillId).IsRequired();
        }
    }
}
