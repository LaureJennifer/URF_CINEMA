using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Client.Data;
using BaseSolution.Client.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Client.ValueObjects.Pagination;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        public Task<bool> AddAsync(BookingCreateRequest request);
        public Task<bool> UpdateAsync(BookingUpdateRequest request);

        public Task<bool> DeleteAsync(BookingDeleteRequest request);
        public Task<RequestResult<BookingDto>> GetBookingSeatByIdAsync(string id);
        public Task<RequestResult<FilmDto>> GetByIdAsync(string id);
        public Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request);
        public Task<PaginationResponse<BookingDto>> GetAllActive(ViewBookingWithPaginationRequest request);
        public Task<PaginationResponse<BookingDto>> GetAllForCompare(ViewBookingWithPaginationRequest request);

    }
}
