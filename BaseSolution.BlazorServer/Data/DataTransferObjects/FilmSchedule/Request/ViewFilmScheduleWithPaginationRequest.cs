using BaseSolution.BlazorServer.ValueObjects.Pagination;

namespace BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request
{
    public class ViewFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
