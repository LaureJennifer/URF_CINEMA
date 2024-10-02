using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class FilmDetailEntityConfiguration : IEntityTypeConfiguration<FilmDetailEntity>
    {
        public void Configure(EntityTypeBuilder<FilmDetailEntity> builder)
        {
            builder.ToTable("FilmDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.FilmSchedule).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmScheduleId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Film).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
