using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class RoomLayoutRepo : IRoomLayoutRepo
    {
        public async Task<bool> AddAsync(RoomLayoutCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/RoomLayouts", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<RoomLayoutListWithPaginationViewModel> GetAllActive()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var obj = await client.GetFromJsonAsync<RoomLayoutListWithPaginationViewModel>($"api/RoomLayouts");


            if (obj != null)
                return obj;
            return new();
        }
    }
}
