using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface IRoomByFilmScheduleRepo
    {
        public Task<RoomByFilmScheduleListWithPaginationViewModel> GetRoomByFilmScheduleAsync(ViewRoomByFilmScheduleWithPaginationRequest request);
    }
}
