using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Role.Request
{
    public class ViewRoleWithPaginationRequest : PaginationRequest
    {
        public string? Code { get; set; }

    }
}
