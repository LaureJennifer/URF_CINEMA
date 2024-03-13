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
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.RoomLayoutEntity).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomLayoutId).IsRequired();
            builder.HasOne(x => x.DepartmentEntity).WithMany(x => x.Rooms).HasForeignKey(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x=>x.Code).IsRequired();
        }
    }
}
