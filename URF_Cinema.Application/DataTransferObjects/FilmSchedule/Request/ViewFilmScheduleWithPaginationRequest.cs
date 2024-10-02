using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request
{
    public class ViewFilmScheduleWithPaginationRequest : PaginationRequest
    {
        public DateTimeOffset? ShowDate { get; set; }
        public DateTimeOffset? ShowTime { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
