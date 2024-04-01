using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Data.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.ValueObjects.Response;


namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        public Task<RequestResult<FilmDto>> GetByIdAsync(string id);
        public Task<FilmScheduleListWithPaginationViewModel> GetAllFilmSchedule(ViewFilmScheduleWithPaginationRequest request);
        public Task<BookingListWithPaginationViewModel> GetAllActive(ViewBookingWithPaginationRequest request);
    }
}
