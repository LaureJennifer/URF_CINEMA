using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
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

        public async Task<SeatListWithPaginationViewModel> GetAllActive(ViewSeatWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<SeatListWithPaginationViewModel>($"api/Seats?RoomLayoutId={request.RoomLayoutId}&PageSize={request.PageSize}");
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

        public async Task<RequestResult<SeatDeleteRequest>> RemoveAsync(SeatDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Seats/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<SeatDeleteRequest>>(obj);
            return result;
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
