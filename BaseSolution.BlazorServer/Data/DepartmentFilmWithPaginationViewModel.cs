using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class DepartmentFilmWithPaginationViewModel: APIResponse
    {
        public PaginationResponse<DepartmentFilmDto>? Data { get; set; }
    }
}
