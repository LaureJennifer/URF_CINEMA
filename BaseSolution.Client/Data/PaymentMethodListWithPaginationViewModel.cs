using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class PaymentMethodListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<PaymentMethodDto>? Data { get; set; }
    }
}
