using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBookingReadWriteRepository
    {
        Task<RequestResult<Guid>> AddBookingAsync(BookingEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateBookingAsync(BookingEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteBookingAsync(BookingDeleteRequest request, CancellationToken cancellationToken);
    }
}
