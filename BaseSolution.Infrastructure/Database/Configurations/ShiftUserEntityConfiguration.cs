using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class ShiftUserEntityConfiguration : IEntityTypeConfiguration<ShiftUserEntity>
    {
        public void Configure(EntityTypeBuilder<ShiftUserEntity> builder)
        {
            builder.ToTable("ShiftUser");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.User).WithMany(x => x.ShiftUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Shift).WithMany(x => x.ShiftUsers).HasForeignKey(x => x.ShiftId);
        }
    }
}
