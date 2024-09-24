using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.ValueObjects.Pagination;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IDepartmentFilmRepo
    {
        public Task<DepartmentFilmWithPaginationViewModel> GetAllActive(ViewDepartmentFilmWithPaginationRequest request);
        Task<PaginationResponse<DepartmentFilmDto>> GetAllDepartmentFilmByDepartment(ViewDepartmentFilmWithPaginationRequest request);

    }
}
