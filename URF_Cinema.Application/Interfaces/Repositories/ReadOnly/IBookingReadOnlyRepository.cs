using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.DataTransferObjects.Booking.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBookingReadOnlyRepository
    {
        Task<RequestResult<BookingDto?>> GetBookingByIdAsync(Guid idBooking, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<BookingDto>>> GetBookingWithPaginationByAdminAsync(
            ViewBookingWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
