using URF_Cinema.Application.DataTransferObjects.Ticket;
using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace URF_Cinema.Client.Repositories.Implements
{
    public class TicketRepo : ITicketRepo
    {
        public async Task<bool> AddAsync(TicketCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/Tickets", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<TicketListWithPaginationViewModel> GetAllActive(ViewTicketWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<TicketListWithPaginationViewModel>($"api/Tickets");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<TicketDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<TicketDto>>($"api/Tickets/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<TicketDeleteRequest>> RemoveAsync([FromQuery]TicketDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Tickets/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<TicketDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(TicketUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Tickets", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
