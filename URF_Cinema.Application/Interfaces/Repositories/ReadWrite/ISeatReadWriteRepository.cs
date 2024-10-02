using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface ISeatReadWriteRepository
    {
        Task<RequestResult<Guid>> AddSeatAsync(SeatEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateSeatAsync(SeatEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteSeatAsync(SeatDeleteRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<Guid>>> CreateRangeSeatAsync(List<SeatEntity> requests, CancellationToken cancellationToken);
    }
}
