using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Data.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Client.Repositories.Interfaces;
using URF_Cinema.Client.Data.ValueObjects.Response;
using URF_Cinema.Client.Data.ValueObjects.Pagination;

namespace URF_Cinema.Client.Repositories.Implements
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

        public  Task<bool> DeleteAsync(BookingDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationResponse<BookingDto>> GetAllActive(ViewBookingWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var expiredTime = request.ExpiredTime?.ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
            var createdTime = request.CreatedTime?.ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz");
            var obj = await client.GetFromJsonAsync<PaginationResponse<BookingDto>>($"api/Bookings?SeatId={request.SeatId}&RoomId={request.RoomId}&DepartmentId={request.DepartmentId}&FilmId={request.FilmId}&FilmScheduleId={request.FilmScheduleId}&SeatStatus={request.SeatStatus}&ExpiredTime={Uri.EscapeDataString(expiredTime)}&CreatedTime={Uri.EscapeDataString(createdTime)}&PageSize={request.PageSize}");
            if (obj != null)
                return obj;
            return new();
        }
        public async Task<PaginationResponse<BookingDto>> GetAllForCompare(ViewBookingWithPaginationRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<PaginationResponse<BookingDto>>($"api/Bookings?RoomId={request.RoomId}&DepartmentId={request.DepartmentId}&FilmId={request.FilmId}&FilmScheduleId={request.FilmScheduleId}&PageSize={request.PageSize}");
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

        public async Task<RequestResult<BookingDto>> GetBookingSeatByIdAsync(string id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<BookingDto>>($"api/Bookings/{id}");
            if (obj != null)
                return obj;
            return null;
        }
    }
}
