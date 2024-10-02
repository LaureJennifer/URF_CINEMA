using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Seat;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface ISeatReadOnlyRepository
    {
        Task<RequestResult<SeatDto?>> GetSeatByIdAsync(Guid idSeat, CancellationToken cancellationToken);
        Task<RequestResult<List<SeatDto>>> GetListSeatByIdAsync(List<Guid> listIdSeat, CancellationToken cancellationToken);

        Task<RequestResult<PaginationResponse<SeatDto>>> GetSeatWithPaginationByAdminAsync(
            ViewSeatWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<SeatDto>> GetSeatByCodeAsync(string code, CancellationToken cancellationToken);

    }
}
