using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.DataTransferObjects.Film;
using BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request;
using BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IBookingFilmRepo
    {
        public Task<RequestResult<FilmDto>> GetByIdAsync(string id);
        public Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request);
    }
}
