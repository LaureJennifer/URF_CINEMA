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
    public class BillDetailEntityConfiguration : IEntityTypeConfiguration<BillDetailEntity>
    {
        public void Configure(EntityTypeBuilder<BillDetailEntity> builder)
        {
            builder.ToTable("BillDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.billEntity).WithMany(x => x.BillDetailEntities).HasForeignKey(x => x.BillId);
            builder.HasOne(x => x.filmEntity).WithOne().HasForeignKey<BillDetailEntity>(x => x.FilmId).IsRequired(false);
        }
    }
}
