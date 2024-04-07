using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class RoomRepo : IRoomRepo
    {
        public async Task<bool> AddAsync(RoomCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Rooms", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<RoomListWithPaginationViewModel> GetAllActive(ViewRoomWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RoomListWithPaginationViewModel>($"api/Rooms");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<RoomDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<RoomDto>>($"api/Rooms/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<RoomDeleteRequest>> RemoveAsync([FromQuery]RoomDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Rooms/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<RoomDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(RoomUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Rooms", request); ;
            return obj.IsSuccessStatusCode; ;
        }
    }
}
