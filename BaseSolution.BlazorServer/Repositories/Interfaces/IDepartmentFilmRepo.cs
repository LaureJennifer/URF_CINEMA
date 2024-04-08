

using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.ValueObjects.Pagination;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IDepartmentFilmRepo
    {
        public Task<DepartmentFilmWithPaginationViewModel> GetAllActive(ViewDepartmentFilmWithPaginationRequest request);
        Task<PaginationResponse<DepartmentFilmDto>> GetAllDepartmentFilmByDepartment(ViewDepartmentFilmWithPaginationRequest request);

    }
}
