using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;


namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface ISeatReadWriteRepository
    {
        Task<RequestResult<Guid>> AddSeatAsync(SeatEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateSeatAsync(SeatEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteSeatAsync(SeatDeleteRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<Guid>>> CreateRangeSeatAsync(List<SeatEntity> requests, CancellationToken cancellationToken);
    }
}
