using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class DepartmentFilmWithPaginationViewModel: APIResponse
    {
        public PaginationResponse<DepartmentFilmDto>? Data { get; set; }
    }
}
