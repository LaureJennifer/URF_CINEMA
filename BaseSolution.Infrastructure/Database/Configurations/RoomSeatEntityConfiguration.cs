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
    public class RoomSeatEntityConfiguration : IEntityTypeConfiguration<RoomSeatEntity>
    {
        public void Configure(EntityTypeBuilder<RoomSeatEntity> builder)
        {
            builder.ToTable("RoomSeat");
            builder.HasKey(x => new { x.SeatId, x.RoomId });
            builder.HasOne(x => x.RoomEntity).WithMany(x => x.RoomSeatEntities).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.SeatEntity).WithMany(x => x.roomSeatEntities).HasForeignKey(x => x.SeatId);
        }
    }
}
