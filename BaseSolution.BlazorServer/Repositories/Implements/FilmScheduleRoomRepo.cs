using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;
using BaseSolution.Infrastructure.ViewModels.FilmScheduleRoom;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmScheduleRoomRepo : IFilmScheduleRoomRepo
    {
        public async Task<bool> AddAsync(FilmScheduleRoomCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/FilmScheduleRooms", request);
            return obj.IsSuccessStatusCode;
        }

        public async Task<bool> AddRangeAsync(List<FilmScheduleRoomCreateRangeRequest> request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/FilmScheduleRooms/CreateRangeFilmScheduleRoom", request);
            return obj.IsSuccessStatusCode;
        }

        public async Task<FilmScheduleListWithPaginationViewModel> GetAllScheduleAsync(ViewFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var url = $"/api/FilmSchedules?PageSize={request.PageSize}";

            var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationViewModel>(url);
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<Data.ValueObjects.FilmScheduleRoomListWithPaginationViewModel> GetFilmScheduleRoomByRoomAsync(ViewFilmScheduleRoomWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            
            var url = $"/api/FilmScheduleRooms?RoomId={request.RoomId}&PageSize={request.PageSize}";
            if (request.FilmScheduleId != null && request.RoomId==null)
            {
                url = $"/api/FilmScheduleRooms?FilmScheduleId={request.FilmScheduleId}&PageSize={request.PageSize}";
            }
            else 
                if (request.FilmScheduleId != null && request.RoomId != null)
            {
                url = $"/api/FilmScheduleRooms?RoomId={request.RoomId}&FilmScheduleId={request.FilmScheduleId}&PageSize={request.PageSize}";
            }
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

        public async Task<bool> RemoveAsync(FilmScheduleRoomDeleteRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"/api/FilmScheduleRooms?Id={request.Id}";
            if (!string.IsNullOrWhiteSpace(request.DeletedBy.ToString()))
            {
                url += $"&DeletedBy={request.DeletedBy}";
            }
            var result = await client.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(FilmScheduleRoomUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/FilmScheduleRooms", request); 
            return obj.IsSuccessStatusCode;
        }
    }
}
