using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;
using BaseSolution.Client.Repositories.Interfaces;

namespace BaseSolution.Client.Repositories.Implements
{
    public class SeatRepo : ISeatRepo
    {
        public async Task<bool> AddAsync(SeatCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Seats", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<bool> AddRangeAsync(List<SeatCreateRangeRequest> request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Seats/CreateRangeSeat", request); 
            return obj.IsSuccessStatusCode;
        }

        public async Task<SeatListWithPaginationViewModel> GetAllActive(ViewSeatWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/Seats?PageSize={request.PageSize}";
            if (request.RoomLayoutId != null)
            {               
                url = $"api/Seats?RoomLayoutId={request.RoomLayoutId}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<SeatListWithPaginationViewModel>(url);
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<SeatDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<SeatDto>>($"api/Seats/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<bool> RemoveAsync(SeatDeleteRequest request)
        {
           
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"/api/Seats?Id={request.Id}";
            if (!string.IsNullOrWhiteSpace(request.DeletedBy.ToString()))
            {
                url += $"&DeletedBy={request.DeletedBy}";
            }
            var result = await client.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(SeatUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Seats", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
