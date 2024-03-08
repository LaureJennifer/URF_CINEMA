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
    public class DepartmentFilmEntityConfiguration : IEntityTypeConfiguration<DepartmentFilmEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentFilmEntity> builder)
        {
            builder.ToTable("DepartmentFilm");
            builder.HasKey(x => new { x.DepartmentId, x.FilmId });
            builder.HasOne(x => x.DepartmentEntity).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.FilmEntity).WithMany(x => x.DepartmentFilms).HasForeignKey(x => x.FilmId);
        }
    }
}
