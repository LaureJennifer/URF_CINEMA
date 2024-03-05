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
    public class FilmScheduleEntiConfiguration : IEntityTypeConfiguration<FilmScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<FilmScheduleEntity> builder)
        {
            builder.ToTable("FilmSchedule");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Film).WithMany(x => x.filmScheduleEntities).UsingEntity(x=>x.ToTable("FilmScheduleWithFilm"));
        }
    }
}
