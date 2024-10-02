using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Data.ValueObjects;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
