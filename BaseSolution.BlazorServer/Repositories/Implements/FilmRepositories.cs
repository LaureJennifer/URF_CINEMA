using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmRepositories : IFilmRepositories
    {
        public async Task<FilmListWithPaginationViewModel> GetAllActive()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var obj = await client.GetFromJsonAsync<FilmListWithPaginationViewModel>($"api/Films");


            if (obj != null)
                return obj;
            return new();
        }
    }
}
