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
    public class TicketEntityConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.ToTable("Ticket");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.FilmEntity).WithMany(x => x.Tickets).HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.BillEntity).WithMany(x => x.Tickets).HasForeignKey(x => x.BillId).IsRequired(false);
            builder.HasOne(x => x.BookingEntity).WithOne().HasForeignKey<TicketEntity>(x => x.BookingId).IsRequired();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
