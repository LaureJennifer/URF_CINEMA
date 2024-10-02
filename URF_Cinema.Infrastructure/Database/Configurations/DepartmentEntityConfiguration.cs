using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Address).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
        }
    }
}
