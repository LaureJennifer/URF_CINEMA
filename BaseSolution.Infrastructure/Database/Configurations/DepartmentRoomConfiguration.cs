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
    public class DepartmentRoomConfiguration : IEntityTypeConfiguration<DepartmentRoomEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentRoomEntity> builder)
        {
            builder.ToTable("DepartmentRoom");
            builder.HasKey(x => new { x.DepartmentId, x.RoomId });
            builder.HasOne(x => x.room).WithMany(x => x.departmentRoomEntities).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.department).WithMany(x => x.DepartmentRoomEntities).HasForeignKey(x => x.DepartmentId);
        }
    }
}
