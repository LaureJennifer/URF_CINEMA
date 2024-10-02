using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class FilmScheduleRoomEntityConfiguration : IEntityTypeConfiguration<FilmScheduleRoomEntity>
    {
        public void Configure(EntityTypeBuilder<FilmScheduleRoomEntity> builder)
        {
            builder.ToTable("FilmScheduleRoom");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Room).WithMany(x => x.FilmScheduleRooms).HasForeignKey(x => x.RoomId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FilmSchedule).WithMany(x => x.FilmScheduleRooms).HasForeignKey(x => x.FilmScheduleId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
