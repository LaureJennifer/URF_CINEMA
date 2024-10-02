using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace URF_Cinema.Client.Repositories.Implements
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
            var obj = await client.GetFromJsonAsync<FilmDetailListWithPaginationViewModel>($"api/FilmDetails?PageSize={request.PageSize}");
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

        public async Task<FilmDetailListWithPaginationViewModel> GetFilmScheduleByFilm(ViewFilmDetailWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<FilmDetailListWithPaginationViewModel>($"api/FilmDetails?FilmId={request.FilmId}&PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
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
