namespace URF_Cinema.Application.DataTransferObjects.VnPayment
{
    public class VnPaymentDto
    {
        public bool Success { get; set; }
        public string PaymentMethod { get; set; }
        public string BookingDescription { get; set; }
        public string BookingId { get; set; }
        public string PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }

    }
}
