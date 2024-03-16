using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBookingReadOnlyRepository
    {
        Task<RequestResult<BookingDto?>> GetBookingByIdAsync(Guid idBooking, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<BookingDto>>> GetBookingWithPaginationByAdminAsync(
            ViewBookingWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
