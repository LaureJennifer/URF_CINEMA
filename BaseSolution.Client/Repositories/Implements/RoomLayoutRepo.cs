using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.Repositories.Interfaces;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Implements
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

        public async Task<RoomLayoutListWithPaginationViewModel> GetAllActive(ViewRoomLayoutWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/RoomLayouts?PageSize={request.PageSize}";
            if (!string.IsNullOrEmpty(request.Name))
            {
                url = $"api/RoomLayouts?Name={request.Name}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<RoomLayoutListWithPaginationViewModel>(url);


            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<RoomLayoutDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<RoomLayoutDto>>($"api/RoomLayouts/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<RoomLayoutDto>> GetByNameAsync(string roomLayoutName)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<RoomLayoutDto>>($"api/RoomLayouts/name?RoomLayoutName={roomLayoutName}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<bool> RemoveAsync(RoomLayoutDeleteRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"/api/RoomLayouts?Id={request.Id}";
            if (!string.IsNullOrWhiteSpace(request.DeletedBy.ToString()))
            {
                url += $"&DeletedBy={request.DeletedBy}";
            }
            var result = await client.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(RoomLayoutUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/RoomLayouts", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
