using BaseSolution.Client.ValueObjects.Pagination;

namespace BaseSolution.Client.Data.DataTransferObjects.Film.Request
{
    public class ViewFilmWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
