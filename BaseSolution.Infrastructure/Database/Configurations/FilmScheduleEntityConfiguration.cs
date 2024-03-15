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
    public class FilmScheduleEntityConfiguration : IEntityTypeConfiguration<FilmScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<FilmScheduleEntity> builder)
        {
            builder.ToTable("FilmSchedule");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
