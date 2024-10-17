using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmReadOnlyRepository
    {
        Task<RequestResult<FilmDto?>> GetFilmByIdAsync(Guid idFilm, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmWithPaginationByAdminAsync(
            ViewFilmWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmsWithDepartmentPaginationAsync(
            ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
