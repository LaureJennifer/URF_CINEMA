using BaseSolution.BlazorServer.ValueObjects.Pagination;

namespace BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request
{
    public class ViewFilmWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
