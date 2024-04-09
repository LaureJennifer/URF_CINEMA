using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;
using BaseSolution.Infrastructure.ViewModels.FilmScheduleRoom;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmScheduleRoomRepo : IFilmScheduleRoomRepo
    {
        public async Task<Data.ValueObjects.FilmScheduleRoomListWithPaginationViewModel> GetFilmScheduleRoomByRoomAsync(ViewFilmScheduleRoomWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var url = $"/api/FilmScheduleRooms?RoomId={request.RoomId}&PageSize={request.PageSize}";

            var obj = await client.GetFromJsonAsync<Data.ValueObjects.FilmScheduleRoomListWithPaginationViewModel>(url);
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<FilmScheduleRoomDto>> GetFilmScheduleRoomByShowDateTimeAsync(FilmScheduleRoomFindByDateTimeRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var showDate = request.ShowTime?.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            var showTime = request.ShowTime?.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");

            var url = $"/api/FilmScheduleRooms/showDateTime?ShowDate={Uri.EscapeDataString(showDate)}&ShowTime={Uri.EscapeDataString(showTime)}";

            var obj = await client.GetFromJsonAsync<RequestResult<FilmScheduleRoomDto>>(url);
            if (obj != null)
                return obj;
            return null;

        }
    }
}
