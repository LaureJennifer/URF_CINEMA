using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class DepartmentProductEntityConfiguration : IEntityTypeConfiguration<DepartmentProductEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentProductEntity> builder)
        {
            builder.ToTable("DepartmentProduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentProducts).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Product).WithMany(x => x.DepartmentProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
