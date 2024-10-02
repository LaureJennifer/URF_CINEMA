using URF_Cinema.Client.Data.ValueObjects.Pagination;

namespace URF_Cinema.Client.Data.DataTransferObjects.FilmSchedule.Request
{
    public class ViewFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
