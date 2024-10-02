using URF_Cinema.Application.DataTransferObjects.PaymentMethod;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class PaymentMethodListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<PaymentMethodDto>? Data { get; set; }
    }
}
