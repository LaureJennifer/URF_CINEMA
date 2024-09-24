using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class FilmDetailEntityConfiguration : IEntityTypeConfiguration<FilmDetailEntity>
    {
        public void Configure(EntityTypeBuilder<FilmDetailEntity> builder)
        {
            builder.ToTable("FilmDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.FilmSchedule).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmScheduleId).IsRequired();
            builder.HasOne(x => x.Film).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmId).IsRequired();
        }
    }
}
