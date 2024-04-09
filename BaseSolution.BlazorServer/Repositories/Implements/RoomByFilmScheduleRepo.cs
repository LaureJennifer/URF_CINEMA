using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class RoomByFilmScheduleRepo : IRoomByFilmScheduleRepo
    {
        public async Task<RoomByFilmScheduleListWithPaginationViewModel> GetRoomByFilmScheduleAsync(ViewRoomByFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var url = $"/api/FilmScheduleRooms/getRoomIdByFilmSchedule?FilmScheduleId={request.FilmScheduleId}&PageSize={request.PageSize}";

            var obj = await client.GetFromJsonAsync<RoomByFilmScheduleListWithPaginationViewModel>(url);
            if (obj != null)
                return obj;
            return null;
        }
    }
}
