using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace URF_Cinema.Client.Repositories.Implements
{
    public class TransactionRepo : ITransactionRepo
    {
        public async Task<bool> AddAsync(TransactionCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Transactions", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<TransactionListWithPaginationViewModel> GetAllActive(ViewTransactionWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<TransactionListWithPaginationViewModel>($"api/Transactions");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<TransactionDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<TransactionDto>>($"api/Transactions/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<TransactionDeleteRequest>> RemoveAsync([FromQuery]TransactionDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Transactions/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<TransactionDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(TransactionUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Transactions", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
