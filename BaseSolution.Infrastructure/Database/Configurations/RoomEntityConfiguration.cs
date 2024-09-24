using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.RoomLayout).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomLayoutId).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Rooms).HasForeignKey(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x=>x.Code).IsRequired();
        }
    }
}
