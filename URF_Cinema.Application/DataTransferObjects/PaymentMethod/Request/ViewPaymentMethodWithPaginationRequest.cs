using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request
{
    public class ViewPaymentMethodWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }
    }
}
