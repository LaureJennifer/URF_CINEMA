using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.SeatEntity).WithMany(x => x.Bookings).HasForeignKey(x => x.SeatId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.RoomEntity).WithMany(x=>x.Bookings).HasForeignKey(x=>x.RoomId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DepartmentEntity).WithMany(x => x.Bookings).HasForeignKey(x => x.DepartmentId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FilmEntity).WithMany(x => x.Bookings).HasForeignKey(x => x.FilmId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FilmScheduleEntity).WithMany(x => x.Bookings).HasForeignKey(x => x.FilmScheduleId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
