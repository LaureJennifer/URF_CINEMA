using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Data.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Manage.Data.ValueObjects.Pagination;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
