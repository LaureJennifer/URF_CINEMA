using URF_Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace URF_Cinema.Infrastructure.Database.Configurations
{
    public class TicketEntityConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.ToTable("Ticket");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Bill).WithMany(x => x.Tickets).HasForeignKey(x => x.BillId).IsRequired(false);
            builder.HasOne(x => x.Booking).WithOne().HasForeignKey<TicketEntity>(x => x.BookingId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Film).WithMany(x => x.Tickets).HasForeignKey(x => x.FilmId).IsRequired();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
