using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmReadOnlyRepository
    {
        Task<RequestResult<FilmDto?>> GetFilmByIdAsync(Guid idFilm, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmDto>>> GetFilmWithPaginationByAdminAsync(
            ViewFilmWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
