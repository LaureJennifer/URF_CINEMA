using BaseSolution.Client.ValueObjects.Pagination;

namespace BaseSolution.Client.Data.DataTransferObjects.FilmSchedule.Request
{
    public class ViewFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
