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
    public class FilmEntityConfiguration : IEntityTypeConfiguration<FilmEntity>
    {
        public void Configure(EntityTypeBuilder<FilmEntity> builder)
        {
            builder.ToTable("Film");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.SneakShow).WithMany(x => x.Films).HasForeignKey(x => x.SneakShowId);
            builder.Property(x=>x.Name).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Description).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Type).IsUnicode(true).IsRequired();
            builder.Property(x => x.Description).IsUnicode(true);
            builder.Property(x => x.Language).IsUnicode(true);
        }
    }
}
