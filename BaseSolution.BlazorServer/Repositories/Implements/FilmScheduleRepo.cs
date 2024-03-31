using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmDetailRepo : IFilmDetailRepo
    {
        public async Task<bool> AddAsync(FilmDetailCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PostAsJsonAsync("api/FilmDetails", request); ;
            return obj.IsSuccessStatusCode;
        }

        public async Task<FilmDetailListWithPaginationViewModel> GetAllActive(ViewFilmDetailWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<FilmDetailListWithPaginationViewModel>($"api/FilmDetails");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<FilmDetailDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<FilmDetailDto>>($"api/FilmDetails/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<FilmDetailDeleteRequest>> RemoveAsync([FromQuery] FilmDetailDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/FilmDetails/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<FilmDetailDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(FilmDetailUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/FilmDetails", request); ;
            return obj.IsSuccessStatusCode;
        }
    }
}
