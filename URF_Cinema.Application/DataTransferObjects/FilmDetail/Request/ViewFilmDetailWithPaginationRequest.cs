using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmDetail.Request
{
    public class ViewFilmDetailWithPaginationRequest :PaginationRequest
    {
        public Guid? FilmId { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public string? FilmName { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
