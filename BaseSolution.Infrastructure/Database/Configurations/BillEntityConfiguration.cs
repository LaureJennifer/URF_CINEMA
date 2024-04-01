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
    public class BillEntityConfiguration : IEntityTypeConfiguration<BillEntity>
    {
        public void Configure(EntityTypeBuilder<BillEntity> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.CustomerEntity).WithMany(x => x.Bills).HasForeignKey(x => x.CustomerId).IsRequired();
            builder.HasOne(x => x.DepartmentEntity).WithMany(x => x.Bills).HasForeignKey(x => x.DepartmentId).IsRequired();

        }
    }
}
