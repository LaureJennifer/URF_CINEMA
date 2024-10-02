namespace URF_Cinema.Application.DataTransferObjects.Merchant
{
    public class MerchantDto
    {
        public Guid Id { get; set; }
        public string? MerchantName { get; set; } = string.Empty;
        public string? MerchantWebLink { get; set; } = string.Empty;
        public string? MerchantIpnUrl { get; set; } = string.Empty;
        public string? MerchantReturnUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
