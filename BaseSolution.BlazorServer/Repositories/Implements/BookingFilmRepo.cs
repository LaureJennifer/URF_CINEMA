using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.BlazorServer.Data;

using BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request;
using BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;
using Newtonsoft.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class BookingFilmRepo : IBookingFilmRepo
    {
        public async Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationViewModel>($"api/FilmSchedules");
            if (obj != null)
                return obj;
            return new();
        }

        //public async Task<RequestResult<FilmScheduleListWithPaginationRequestViewModel>> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request)
        //{
        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri("https://localhost:7005")
        //    };
        //    var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationRequestViewModel>($"api/FilmSchedules");


        //    if (obj != null)
        //        return obj;
        //    return new();
        //}

        public async Task<RequestResult<FilmDto>> GetByIdAsync(string id)
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

    }
}
