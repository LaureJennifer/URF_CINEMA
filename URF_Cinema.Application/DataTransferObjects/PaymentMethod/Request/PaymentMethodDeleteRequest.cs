namespace URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request
{
    public class PaymentMethodDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
