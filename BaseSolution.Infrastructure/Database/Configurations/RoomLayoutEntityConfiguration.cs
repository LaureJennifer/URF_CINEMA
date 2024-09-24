using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class RoomLayoutEntityConfiguration : IEntityTypeConfiguration<RoomLayoutEntity>
    {
        public void Configure(EntityTypeBuilder<RoomLayoutEntity> builder)
        {
            builder.ToTable("RoomLayout");
            builder.HasKey(x =>x.Id);
            builder.Property(x => x.Name).IsUnicode(true).IsRequired();
        }
    }
}
