using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class BillEntityConfiguration : IEntityTypeConfiguration<BillEntity>
    {
        public void Configure(EntityTypeBuilder<BillEntity> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Customer).WithMany(x => x.Bills).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Department).WithMany(x => x.Bills).HasForeignKey(x => x.DepartmentId).IsRequired();
        }
    }
}
