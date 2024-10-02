using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class BillListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<BillDto>? Data { get; set; }
    }
}
