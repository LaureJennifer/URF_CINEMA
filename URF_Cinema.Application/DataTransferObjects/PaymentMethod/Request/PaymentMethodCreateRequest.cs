using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request
{
    public class PaymentMethodCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
