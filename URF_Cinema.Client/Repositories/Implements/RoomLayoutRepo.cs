using URF_Cinema.Application.DataTransferObjects.RoomLayout;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;
using URF_Cinema.Client.Data.ValueObjects.Response;

namespace URF_Cinema.Client.Repositories.Implements
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
