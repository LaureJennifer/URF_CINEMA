using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class BillRepo : IBillRepo
    {
        public async Task<bool> AddAsync(BillCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Bills", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<bool> CreateNewBill(BillCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("/api/Bills", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> CreateNewPayment(CheckoutVM request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("/api/Carts", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<BillListWithPaginationViewModel> GetAllActive(ViewBillWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<BillListWithPaginationViewModel>($"api/Bills");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<BillDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<BillDto>>($"api/Bills/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<BillDeleteRequest>> RemoveAsync([FromQuery]BillDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Bills/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<BillDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(BillUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Bills", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
