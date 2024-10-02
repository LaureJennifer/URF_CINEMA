using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.User.Request
{
    public class ViewUserWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }

        public Guid? RoleId { get; set; }
        public string? Code { get; set; }
        public string value { get; set; } = string.Empty;
    }
}
