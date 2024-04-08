
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.ValueObjects.Pagination;
using BaseSolution.BlazorServer.ValueObjects.Response;


namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        public Task<bool> AddAsync(BookingCreateRequest request);
        public Task<bool> UpdateAsync(BookingUpdateRequest request);

        public Task<bool> DeleteAsync(BookingDeleteRequest request);

        public Task<RequestResult<FilmDto>> GetByIdAsync(string id);
        public Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request);
        public Task<PaginationResponse<BookingDto>> GetAllActive(ViewBookingWithPaginationRequest request);
        public Task<PaginationResponse<BookingDto>> GetAllForCompare(ViewBookingWithPaginationRequest request);

    }
}
