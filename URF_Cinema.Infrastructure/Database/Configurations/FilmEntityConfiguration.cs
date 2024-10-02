using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class FilmEntityConfiguration : IEntityTypeConfiguration<FilmEntity>
    {
        public void Configure(EntityTypeBuilder<FilmEntity> builder)
        {
            builder.ToTable("Film");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x=>x.Title).IsUnicode(true).IsRequired();
            builder.Property(x=>x.DirectedBy).IsUnicode(true).IsRequired();
            builder.Property(x=>x.Actor).IsUnicode(true).IsRequired();
            builder.Property(x => x.Description).IsUnicode(true);
            builder.Property(x => x.Language).IsUnicode(true);
            builder.Property(x=>x.Script).IsUnicode(true);
            builder.Property(x=>x.Genres).IsUnicode(true);

        }
    }
}
