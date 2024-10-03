using Azure;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Google.Apis.Requests.BatchRequest;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class FilmRepo : IFilmRepo
    {
        public async Task<string> AddAsync(FilmCreateRequest request)
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:7005")
            //};
            //var obj = await client.PostAsJsonAsync("api/Films", request); ;
            //return obj.IsSuccessStatusCode;

            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7005")
                };
                var obj = await client.PostAsJsonAsync("api/films", request); ;
                if(obj.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                else
                {
                    var errorDetails = await obj.Content.ReadAsStringAsync();
                    return $"API trả về lỗi: {errorDetails}";
                }
            }
            catch (Exception ex)
            {
                // Trả về thông báo lỗi
                return ex.Message; // Hoặc một thông điệp chi tiết hơn
            }
        }

        public async Task<FilmListWithPaginationViewModel> GetAll()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<FilmListWithPaginationViewModel>($"api/Films");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<FilmListWithPaginationViewModel> GetAllActive(ViewFilmWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            string url = $"api/Films?PageSize={request.PageSize}";
            if (!string.IsNullOrEmpty(request.Title))
            {
                url = $"api/Films?Name={request.Title}&PageSize={request.PageSize}";
            }
            var obj = await client.GetFromJsonAsync<FilmListWithPaginationViewModel>(url);


            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<FilmDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<FilmDto>>($"api/Films/{id}");
            if (obj != null)
                return obj;
            return null;
        }

        public async Task<RequestResult<FilmDeleteRequest>> RemoveAsync([FromQuery]FilmDeleteRequest request)
        {
            var query = $"?Id={request.Id}&DeletedBy={request.DeletedBy}&DeletedDate={request.DeletedTime}";
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.DeleteAsync($"api/Films/{query}").Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RequestResult<FilmDeleteRequest>>(obj);
            return result;
        }

        public async Task<bool> UpdateAsync(FilmUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.PutAsJsonAsync("api/Films", request);
            return obj.IsSuccessStatusCode;
            #region
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:7005")
            //};

            //var obj = await client.PutAsJsonAsync("api/Films", request);
            //if(obj.IsSuccessStatusCode)
            //{
            //    return string.Empty;
            //}
            //else
            //{
            //    var errorDetails = await obj.Content.ReadAsStringAsync();
            //    Console.WriteLine(errorDetails);
            //    return $"Cập nhật thất bại: {errorDetails}";
            //}
            #endregion
        }
    }
}
