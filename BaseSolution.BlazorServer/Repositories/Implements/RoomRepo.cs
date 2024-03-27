using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;
using System.Net.Http;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class RoomRepo : IRoomRepo
    {
        public async Task<RequestResult<RoomDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.GetFromJsonAsync<RequestResult<RoomDto>>($"/api/Rooms/{id}");
            return result;
        }
    }
}
