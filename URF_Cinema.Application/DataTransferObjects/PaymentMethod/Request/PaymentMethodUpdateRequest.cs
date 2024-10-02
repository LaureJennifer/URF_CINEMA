using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request
{
    public class PaymentMethodUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
