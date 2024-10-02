using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class DepartmentFilmEntityConfiguration : IEntityTypeConfiguration<DepartmentFilmEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentFilmEntity> builder)
        {
            builder.ToTable("DepartmentFilm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.DepartmentId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Film).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.FilmId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
