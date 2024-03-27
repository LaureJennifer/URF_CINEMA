using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IFilmRepositories
    {
        public Task<FilmListWithPaginationViewModel> GetAllActive();
    }
}
