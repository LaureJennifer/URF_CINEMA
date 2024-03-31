using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IFilmScheduleRoomRepo
    {
        public Task<RequestResult<FilmScheduleRoomDto>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request);
    }
}
