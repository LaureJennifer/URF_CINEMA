using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.Data.ValueObjects;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IFilmScheduleRoomRepo
    {
        public Task<RequestResult<FilmScheduleRoomDto>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request);

        public Task<FilmScheduleListWithPaginationViewModel> GetAllScheduleAsync(ViewFilmScheduleWithPaginationRequest request);
        public Task<FilmScheduleRoomListWithPaginationViewModel> GetFilmScheduleRoomByRoomAsync(ViewFilmScheduleRoomWithPaginationRequest request);

        public Task<bool> AddRangeAsync(List<FilmScheduleRoomCreateRangeRequest> request);

        public Task<bool> RemoveAsync(FilmScheduleRoomDeleteRequest request);
        public Task<bool> AddAsync(FilmScheduleRoomCreateRequest request);
        public Task<bool> UpdateAsync(FilmScheduleRoomUpdateRequest request);
    }
}
