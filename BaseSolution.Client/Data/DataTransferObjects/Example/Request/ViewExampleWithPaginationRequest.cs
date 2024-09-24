using BaseSolution.Client.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;

namespace BaseSolution.BlazorServer.Data.DataTransferObjects.Example.Request
{
    public class ViewExampleWithPaginationRequest : PaginationRequest
    {
        // SearchFields
        public string? Name { get; set; }

        // SortFields
        public EntityStatus? Status { get; set; }
    }
}
