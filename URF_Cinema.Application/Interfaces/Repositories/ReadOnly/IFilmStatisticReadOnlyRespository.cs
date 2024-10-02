using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmStatisticReadOnlyRespository
    {
        Task<RequestResult<List<FilmStatisticForMonthDto>>> GetFilmStatisticForMonthAsync(
       FilmStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<FilmStatisticForQuarterDto>>> GetFilmStatisticForQuarterAsync(
        FilmStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<FilmStatisticForYearDto>>> GetFilmStatisticForYearAsync(
        FilmStatisticRequest request, CancellationToken cancellationToken);
    }
}
