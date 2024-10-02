using URF_Cinema.Client.Data.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.BlazorServer.Data.DataTransferObjects.Example.Request
{
    public class ViewExampleWithPaginationRequest : PaginationRequest
    {
        // SearchFields
        public string? Name { get; set; }

        // SortFields
        public EntityStatus? Status { get; set; }
    }
}
