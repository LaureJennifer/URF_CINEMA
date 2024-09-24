using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).IsRequired();
            builder.Property(x=>x.Name).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Code).IsRequired();
            builder.Property(x=>x.PhoneNumber).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.StartTime).IsRequired();
            builder.Property(x => x.PassWord).IsRequired();
            builder.Property(x => x.Address).IsUnicode(true).IsRequired();
            builder.Property(x => x.EducationLevel).IsRequired();
            builder.Property(x => x.UrlImage).IsRequired();
            builder.Property(x => x.IdentificationNumber).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
        }
    }
}
