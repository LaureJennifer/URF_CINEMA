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
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasOne(x => x.UserEntity).WithMany(x => x.userRoleEntities).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.RoleEntity).WithMany(x => x.userRoleEntities).HasForeignKey(x => x.RoleId);
        }
    }
}
