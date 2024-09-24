using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class SeatEntityConfiguration : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            builder.ToTable("Seat");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.RoomLayout).WithMany(x => x.Seats).HasForeignKey(x => x.RoomLayoutId).IsRequired();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
