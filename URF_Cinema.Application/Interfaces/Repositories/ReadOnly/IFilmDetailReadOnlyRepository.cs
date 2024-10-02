using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmDetailReadOnlyRepository
    {
        Task<RequestResult<FilmDetailDto?>> GetFilmDetailByIdAsync(Guid idFilmDetail, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmDetailDto>>> GetFilmDetailWithPaginationByAdminAsync(
            ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
