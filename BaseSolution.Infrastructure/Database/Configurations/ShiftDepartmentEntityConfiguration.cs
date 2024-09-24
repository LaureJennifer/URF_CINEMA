using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class ShiftDepartmentEntityConfiguration : IEntityTypeConfiguration<ShiftDepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<ShiftDepartmentEntity> builder)
        {
            builder.ToTable("ShiftDepartment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Department).WithMany(x => x.ShiftDepartments).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Shift).WithMany(x => x.ShiftDepartments).HasForeignKey(x => x.ShiftId);
        }
    }
}
