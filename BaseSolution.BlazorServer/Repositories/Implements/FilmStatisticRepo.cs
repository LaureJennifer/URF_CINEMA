using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.Infrastructure.ViewModels.Statistic.Film;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmStatisticRepo : IFilmStatisticRepo
    {
        public async Task<List<FilmStatisticForMonthDto>> GetFilmStatisticsForMonthAsync(FilmStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/FilmStatistics/FilmStatisticForMonth?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<FilmStatisticForMonthDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FilmStatisticForQuarterDto>> GetFilmStatisticsForQuarterAsync(FilmStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/FilmStatistics/FilmStatisticForQuarter?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<FilmStatisticForQuarterDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FilmStatisticForYearDto>> GetFilmStatisticsForYearAsync(FilmStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/FilmStatistics/FilmStatisticForMonth?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<FilmStatisticForYearDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
