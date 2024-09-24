using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseSolution.Infrastructure.Database.Configurations
{
    public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Bill).WithMany(x=>x.Transactions).HasForeignKey(x => x.BillId).IsRequired();
            builder.HasOne(x => x.PaymentMethod).WithMany(x=>x.Transactions).HasForeignKey(x => x.PaymentMethodId).IsRequired();
            builder.Property(x => x.TransactionReferenceNumber).IsRequired();
        }
    }
}
