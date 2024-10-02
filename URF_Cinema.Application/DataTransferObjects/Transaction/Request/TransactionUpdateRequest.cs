using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Transaction.Request
{
    public class TransactionUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? BillId { get; set; }
        public DateTimeOffset? TransactionDate { get; set; }
        public double? Price { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
