using URF_Cinema.Manage.Data.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Manage.Data.DataTransferObjects.Example.Request
{
    public class ViewExampleWithPaginationRequest : PaginationRequest
    {
        // SearchFields
        public string? Name { get; set; }

        // SortFields
        public EntityStatus? Status { get; set; }
    }
}
