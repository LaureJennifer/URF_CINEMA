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
    public class FacilityEntityConfiguration : IEntityTypeConfiguration<FacilityEntity>
    {
        public void Configure(EntityTypeBuilder<FacilityEntity> builder)
        {
            builder.ToTable("Facility");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsUnicode(true).IsRequired();
        }
    }
}
