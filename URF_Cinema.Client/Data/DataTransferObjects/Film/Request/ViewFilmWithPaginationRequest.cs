using URF_Cinema.Client.Data.ValueObjects.Pagination;

namespace URF_Cinema.Client.Data.DataTransferObjects.Film.Request
{
    public class ViewFilmWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
