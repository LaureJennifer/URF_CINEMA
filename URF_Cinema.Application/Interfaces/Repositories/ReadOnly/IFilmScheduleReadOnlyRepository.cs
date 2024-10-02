using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmScheduleReadOnlyRepository
    {
        Task<RequestResult<FilmScheduleDto?>> GetFilmScheduleByIdAsync(Guid idFilmSchedule, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<FilmScheduleDto>>> GetFilmScheduleWithPaginationByAdminAsync(
            ViewFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
