using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class CustomerListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<CustomerDto>? Data { get; set; }
    }
}
