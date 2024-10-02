namespace URF_Cinema.Application.DataTransferObjects.PaymentMethod
{
    public class PaymentLinkDto
    {
        public Guid PaymentId { get; set; }
        public string PaymentUrl { get; set; } = string.Empty;
    }
}
