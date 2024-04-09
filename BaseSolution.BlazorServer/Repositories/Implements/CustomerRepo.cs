using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class CustomerRepo : ICustomerRepo
    {
        public async Task<bool> AddAsync(CustomerCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Customers", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<CustomerListWithPaginationViewModel> GetAllActive(ViewCustomerWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<CustomerListWithPaginationViewModel>($"api/Customers");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<CustomerDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<CustomerDto>>($"api/Customers/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Customers/register", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<RequestResult<CustomerDeleteRequest>> RemoveAsync([FromQuery]CustomerDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Customers/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<CustomerDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(CustomerUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Customers", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
