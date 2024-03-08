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
    public class FilmScheduleRoomConfiguration : IEntityTypeConfiguration<FilmScheduleRoomEntity>
    {
        public void Configure(EntityTypeBuilder<FilmScheduleRoomEntity> builder)
        {
            builder.ToTable("DepartmentRoom");
            builder.HasKey(x => new { x.FilmScheduleId, x.RoomId });
            builder.HasOne(x => x.RoomEntity).WithMany(x => x.FilmScheduleRooms).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.FilmScheduleEntity).WithMany(x => x.FilmScheduleRooms).HasForeignKey(x => x.FilmScheduleId);
        }
    }
}
