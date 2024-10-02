using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Address).IsUnicode(true).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x=>x.PhoneNumber);
            builder.Property(x=>x.PassWord).IsRequired();
        }
    }
}
