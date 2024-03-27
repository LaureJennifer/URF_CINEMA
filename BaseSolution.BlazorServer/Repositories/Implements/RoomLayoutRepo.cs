using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class RoomLayoutRepo : IRoomLayoutRepo
    {
        public async Task<RequestResult<RoomLayoutDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.GetFromJsonAsync<RequestResult<RoomLayoutDto>>($"/api/RoomLayouts/{id}");
            return result;
        }
    }
}
