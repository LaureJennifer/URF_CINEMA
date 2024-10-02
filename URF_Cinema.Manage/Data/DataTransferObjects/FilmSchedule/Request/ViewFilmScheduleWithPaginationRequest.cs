using URF_Cinema.Manage.Data.ValueObjects.Pagination;

namespace URF_Cinema.Manage.Data.DataTransferObjects.FilmSchedule.Request
{
    public class ViewFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public string value { get; set; } = string.Empty;
    }
}
