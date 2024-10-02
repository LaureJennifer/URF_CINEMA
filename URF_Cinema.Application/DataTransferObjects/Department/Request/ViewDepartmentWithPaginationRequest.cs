using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Department.Request
{
    public class ViewDepartmentWithPaginationRequest : PaginationRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

    }
}
