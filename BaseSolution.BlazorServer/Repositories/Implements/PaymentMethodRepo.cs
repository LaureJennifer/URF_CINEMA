using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class PaymentMethodRepo : IPaymentMethodRepo
    {
        public async Task<bool> AddAsync(PaymentMethodCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/PaymentMethods", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<PaymentMethodListWithPaginationViewModel> GetAllActive(ViewPaymentMethodWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<PaymentMethodListWithPaginationViewModel>($"api/PaymentMethods");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<PaymentMethodDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<PaymentMethodDto>>($"api/PaymentMethods/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<PaymentMethodDeleteRequest>> RemoveAsync([FromQuery]PaymentMethodDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Bills/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<PaymentMethodDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(PaymentMethodUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/PaymentMethods", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
