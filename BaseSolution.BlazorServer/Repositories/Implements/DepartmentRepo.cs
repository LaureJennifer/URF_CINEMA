using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Pagination;

namespace BaseSolution.BlazorServer.Repositories.Implements
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
            var obj = await client.GetFromJsonAsync<DepartmentListWithPaginationViewModel>($"api/Departments?PageSize={request.PageSize}");
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

        public Task<RequestResult<DepartmentDeleteRequest>> RemoveAsync(DepartmentDeleteRequest request)
        {
            throw new NotImplementedException();
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
