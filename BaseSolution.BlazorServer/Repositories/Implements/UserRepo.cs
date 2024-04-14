using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class UserRepo : IUserRepo
    {
        public async Task<bool> AddAsync(UserCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Users", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<UserListWithPaginationViewModel> GetAllActive(ViewUserWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/Users?PageSize={request.PageSize}";
            if (!string.IsNullOrEmpty(request.Name))
            {
                url = $"api/Users?Name={request.Name}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<UserListWithPaginationViewModel>(url);

            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<UserDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<UserDto>>($"api/Users/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<UserDeleteRequest>> RemoveAsync([FromQuery] UserDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Users/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<UserDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(UserUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Users", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
