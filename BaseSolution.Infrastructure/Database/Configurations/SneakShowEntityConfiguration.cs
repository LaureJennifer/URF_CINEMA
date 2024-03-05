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
    public class SneakShowEntityConfiguration : IEntityTypeConfiguration<SneakShowEntity>
    {
        public void Configure(EntityTypeBuilder<SneakShowEntity> builder)
        {
            builder.ToTable("SneakShow");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        }
    }
}
