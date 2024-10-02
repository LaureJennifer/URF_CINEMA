using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Customer.Request
{
    public class ViewCustomerWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }
    }
}
