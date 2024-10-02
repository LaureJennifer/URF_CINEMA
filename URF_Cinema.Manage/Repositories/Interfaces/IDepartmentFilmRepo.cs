using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Data.ValueObjects.Pagination;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface IDepartmentFilmRepo
    {
        public Task<DepartmentFilmWithPaginationViewModel> GetAllActive(ViewDepartmentFilmWithPaginationRequest request);
        Task<PaginationResponse<DepartmentFilmDto>> GetAllDepartmentFilmByDepartment(ViewDepartmentFilmWithPaginationRequest request);

    }
}
