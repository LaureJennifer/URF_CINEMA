using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Bill.Request
{
    public class ViewBillWithPaginationRequest : PaginationRequest
    {
        public Guid? CustomerId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? Code { get; set; }
        public string? CustomerName { get; set; }
        public string? DepartmentName { get; set; }

    }
}
