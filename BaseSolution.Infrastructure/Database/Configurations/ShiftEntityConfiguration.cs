using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class ShiftEntityConfiguration : IEntityTypeConfiguration<ShiftEntity>
    {
        public void Configure(EntityTypeBuilder<ShiftEntity> builder)
        {
            builder.ToTable("Shift");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.ShiftDate).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
        }
    }
}
