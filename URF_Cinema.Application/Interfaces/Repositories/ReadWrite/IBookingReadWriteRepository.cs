using URF_Cinema.Application.DataTransferObjects.Booking.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBookingReadWriteRepository
    {
        Task<RequestResult<Guid>> AddBookingAsync(BookingEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateBookingAsync(BookingEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteBookingAsync(BookingDeleteRequest request, CancellationToken cancellationToken);
    }
}
