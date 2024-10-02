using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Transaction
{
    public class TransactionDto
    {
        public Guid BillId { get; set; }
        public double Price { get; set; }
        public string PaymentMethodName { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public EntityStatus Status { get; set; }
    }
}
