using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IDepartmentFilmReadOnlyRepository
    {
        Task<RequestResult<DepartmentFilmDto?>> GetDepartmentFilmByIdAsync(Guid idDepartmentFilm, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<DepartmentFilmDto>>> GetDepartmentFilmWithPaginationByAdminAsync(
            ViewDepartmentFilmWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
