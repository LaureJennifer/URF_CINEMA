using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;

using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.ValueObjects;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IFilmScheduleRoomRepo
    {
        public Task<RequestResult<FilmScheduleRoomDto>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request);

        public Task<FilmScheduleListWithPaginationViewModel> GetAllScheduleAsync(ViewFilmScheduleWithPaginationRequest request);
        public Task<FilmScheduleRoomListWithPaginationViewModel> GetFilmScheduleRoomByRoomAsync(ViewFilmScheduleRoomWithPaginationRequest request);

        public Task<bool> AddRangeAsync(List<FilmScheduleRoomCreateRangeRequest> request);

        public Task<bool> RemoveAsync(FilmScheduleRoomDeleteRequest request);
        public Task<bool> UpdateAsync(FilmScheduleRoomUpdateRequest request);
    }
}
