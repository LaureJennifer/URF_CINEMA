using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.BlazorServer.Data;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoomByFilmScheduleRepo
    {
        public Task<RoomByFilmScheduleListWithPaginationViewModel> GetRoomByFilmScheduleAsync(ViewRoomByFilmScheduleWithPaginationRequest request);
    }
}
