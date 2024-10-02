namespace URF_Cinema.Application.DataTransferObjects.Customer.Request
{
    public class CustomerDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
