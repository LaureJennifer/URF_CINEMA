using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface IFilmStatisticRepo
    {
        Task<List<FilmStatisticForMonthDto>> GetFilmStatisticsForMonthAsync(FilmStatisticRequest request);
        Task<List<FilmStatisticForQuarterDto>> GetFilmStatisticsForQuarterAsync(FilmStatisticRequest request);
        Task<List<FilmStatisticForYearDto>> GetFilmStatisticsForYearAsync(FilmStatisticRequest request);
    }
}
