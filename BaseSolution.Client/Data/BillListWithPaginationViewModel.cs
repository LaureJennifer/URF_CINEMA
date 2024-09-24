using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class BillListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<BillDto>? Data { get; set; }
    }
}
