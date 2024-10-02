using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Seat).WithMany(x => x.Bookings).HasForeignKey(x => x.SeatId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Room).WithMany(x=>x.Bookings).HasForeignKey(x=>x.RoomId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Customer).WithMany(x => x.Bookings).HasForeignKey(x => x.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
