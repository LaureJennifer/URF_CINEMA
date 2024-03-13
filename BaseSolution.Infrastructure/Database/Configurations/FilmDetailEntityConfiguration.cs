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
    public class FilmDetailEntityConfiguration : IEntityTypeConfiguration<FilmDetailEntity>
    {
        public void Configure(EntityTypeBuilder<FilmDetailEntity> builder)
        {
            builder.ToTable("FilmDetail");
            builder.HasKey(x => new { x.FilmId, x.FilmScheduleId });
            builder.HasOne(x => x.FilmScheduleEntity).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmScheduleId).IsRequired();
            builder.HasOne(x => x.FilmEntity).WithMany(x => x.FilmDetails).HasForeignKey(x => x.FilmId).IsRequired();
        }
    }
}
