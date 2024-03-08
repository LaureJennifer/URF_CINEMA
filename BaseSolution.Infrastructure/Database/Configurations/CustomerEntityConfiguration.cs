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
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.RoleEntity).WithMany(x => x.Customers).HasForeignKey(x => x.RoleId);
            builder.Property(x=>x.Name).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Address).IsUnicode(true).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x=>x.PhoneNumber).IsRequired();
            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x=>x.PassWord).IsRequired();
        }
    }
}
