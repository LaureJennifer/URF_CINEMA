using URF_Cinema.Application.ValueObjects.Pagination;

namespace URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request
{
    public class ViewDepartmentFilmWithPaginationRequest : PaginationRequest
    {
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? FilmTitle { get; set; }
    }
}
