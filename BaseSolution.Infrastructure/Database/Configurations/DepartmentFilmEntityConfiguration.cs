using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class DepartmentFilmEntityConfiguration : IEntityTypeConfiguration<DepartmentFilmEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentFilmEntity> builder)
        {
            builder.ToTable("DepartmentFilm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.DepartmentId).IsRequired();
            builder.HasOne(x => x.Film).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.FilmId).IsRequired();
        }
    }
}
