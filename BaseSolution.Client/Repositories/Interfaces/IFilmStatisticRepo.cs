using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IFilmStatisticRepo
    {
        Task<List<FilmStatisticForMonthDto>> GetFilmStatisticsForMonthAsync(FilmStatisticRequest request);
        Task<List<FilmStatisticForQuarterDto>> GetFilmStatisticsForQuarterAsync(FilmStatisticRequest request);
        Task<List<FilmStatisticForYearDto>> GetFilmStatisticsForYearAsync(FilmStatisticRequest request);
    }
}
