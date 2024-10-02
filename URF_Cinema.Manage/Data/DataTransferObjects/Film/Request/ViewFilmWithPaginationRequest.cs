using URF_Cinema.Manage.Data.ValueObjects.Pagination;

namespace URF_Cinema.Manage.Data.DataTransferObjects.Film.Request
{
    public class ViewFilmWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
