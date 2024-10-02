using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace URF_Cinema.Manage.Repositories.Implements
{
    public class CustomerRepo : ICustomerRepo
    {
        //public async Task<bool> AddAsync(CustomerCreateRequest request)
        //{
        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri("https://localhost:7005")
        //    };
        //    var obj = await client.PostAsJsonAsync("api/Customers", request); ;
        //    return obj.IsSuccessStatusCode;
        //}

        public async Task<CustomerListWithPaginationViewModel> GetAllActive(ViewCustomerWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/Customers?PageSize={request.PageSize}";
            if (!string.IsNullOrEmpty(request.Name))
            {
                url = $"api/Customers?Name={request.Name}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<CustomerListWithPaginationViewModel>(url);

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

        public async Task<RequestResult<CustomerDto>> GetByNameAsync(string userName)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<CustomerDto>>($"api/Customers/{userName}");
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
            var obj = await client.PostAsJsonAsync("api/Customers/Register", request);
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
