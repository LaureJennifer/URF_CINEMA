using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;
using BaseSolution.Client.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolutio.Client.Repositories.Implements
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public async Task<bool> AddAsync(DepartmentCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Departments", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<DepartmentListWithPaginationViewModel> GetAllActive(ViewDepartmentWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/Departments?PageSize={request.PageSize}";
            if (!string.IsNullOrEmpty(request.Name))
            {
                url = $"api/Departments?Name={request.Name}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<DepartmentListWithPaginationViewModel>(url);

            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<DepartmentDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<DepartmentDto>>($"api/Departments/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<DepartmentDeleteRequest>> RemoveAsync([FromQuery]DepartmentDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Departments/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<DepartmentDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(DepartmentUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Departments", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
