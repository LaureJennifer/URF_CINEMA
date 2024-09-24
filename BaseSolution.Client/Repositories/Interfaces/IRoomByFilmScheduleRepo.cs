using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IRoomByFilmScheduleRepo
    {
        public Task<RoomByFilmScheduleListWithPaginationViewModel> GetRoomByFilmScheduleAsync(ViewRoomByFilmScheduleWithPaginationRequest request);
    }
}
