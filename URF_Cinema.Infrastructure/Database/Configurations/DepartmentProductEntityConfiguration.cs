using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class DepartmentProductEntityConfiguration : IEntityTypeConfiguration<DepartmentProductEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentProductEntity> builder)
        {
            builder.ToTable("DepartmentProduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentProducts).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Product).WithMany(x => x.DepartmentProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
