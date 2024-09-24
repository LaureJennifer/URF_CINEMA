using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
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
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
