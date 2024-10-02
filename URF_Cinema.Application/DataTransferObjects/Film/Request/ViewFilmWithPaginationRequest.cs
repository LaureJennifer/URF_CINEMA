using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.Film.Request
{
    public class ViewFilmWithPaginationRequest : PaginationRequest
    {
        public string? Title { get; set; }
        public string? Code { get; set;}
    }
}
