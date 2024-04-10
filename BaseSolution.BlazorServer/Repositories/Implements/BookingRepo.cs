using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.BlazorServer.Data;

using BaseSolution.BlazorServer.Data.DataTransferObjects.Film.Request;
using BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Pagination;
using BaseSolution.BlazorServer.ValueObjects.Response;
using Newtonsoft.Json;
using System.Net.Http;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class BookingRepo : IBookingRepo
    {
        public async Task<bool> AddAsync(BookingCreateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("/api/Bookings", request);
            return result.IsSuccessStatusCode;
        }

        public Task<bool> DeleteAsync(BookingDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ValueObjects.Pagination.PaginationResponse<BookingDto>> GetAllActive(ViewBookingWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var expiredTime = request.ExpiredTime?.ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
            var createdTime = request.CreatedTime?.ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
            var obj = await client.GetFromJsonAsync<ValueObjects.Pagination.PaginationResponse<BookingDto>>($"api/Bookings?SeatId={request.SeatId}&RoomId={request.RoomId}&DepartmentId={request.DepartmentId}&SeatStatus={request.SeatStatus}&ExpiredTime={Uri.EscapeDataString(expiredTime)}&CreatedTime={Uri.EscapeDataString(createdTime)}&PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
        }
        public async Task<ValueObjects.Pagination.PaginationResponse<BookingDto>> GetAllForCompare(ViewBookingWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<ValueObjects.Pagination.PaginationResponse<BookingDto>>($"api/Bookings?RoomId={request.RoomId}&DepartmentId={request.DepartmentId}&PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
        }

        public async Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<FilmScheduleListWithPaginationViewModel>($"api/FilmSchedules?PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
        }

        

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

        public async Task<bool> UpdateAsync(BookingUpdateRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PutAsJsonAsync("/api/Bookings", request);
            return result.IsSuccessStatusCode;
        }
    }
}
