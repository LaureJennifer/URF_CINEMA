using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IDepartmentFilmReadOnlyRepository
    {
        Task<RequestResult<DepartmentFilmDto?>> GetDepartmentFilmByIdAsync(Guid idDepartmentFilm, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<DepartmentFilmDto>>> GetDepartmentFilmWithPaginationByAdminAsync(
            ViewDepartmentFilmWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
