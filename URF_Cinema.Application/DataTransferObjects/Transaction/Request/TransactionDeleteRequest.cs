namespace URF_Cinema.Application.DataTransferObjects.Transaction.Request
{
    public class TransactionDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
