using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class CustomerListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<CustomerDto>? Data { get; set; }
    }
}
