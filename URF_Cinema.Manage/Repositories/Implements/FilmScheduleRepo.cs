using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Repositories.Interfaces;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Implements
{
    public class FilmScheduleRepo : IFilmScheduleRepo
    {
        public async Task<bool> AddAsync(FilmScheduleCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/FilmSchedules", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(FilmScheduleDeleteRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"/api/FilmSchedules?Id={request.Id}";
            if (!string.IsNullOrWhiteSpace(request.DeletedBy.ToString()))
            {
                url += $"&DeletedBy={request.DeletedBy}";
            }
            var result = await client.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        public async Task<FilmScheduleListWithPaginationViewModel> GetAllActive(ViewFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            
            var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationViewModel>($"api/FilmSchedules?PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<FilmScheduleListWithPaginationViewModel> GetByShowDateTime(ViewFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var showDate = request.ShowDate?.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            var showTime = request.ShowTime?.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationViewModel>($"api/FilmSchedules?ShowDate={Uri.EscapeDataString(showDate)}&ShowTime={Uri.EscapeDataString(showTime)}");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<FilmScheduleDto>> GetFilmScheduleByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<FilmScheduleDto>>($"api/FilmSchedules/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<bool> UpdateAsync(FilmScheduleUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/FilmSchedules", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
