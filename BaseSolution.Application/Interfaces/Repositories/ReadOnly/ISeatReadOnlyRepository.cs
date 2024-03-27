using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.DataTransferObjects.Example;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.DataTransferObjects.User;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface ISeatReadOnlyRepository
    {
        Task<RequestResult<SeatDto?>> GetSeatByIdAsync(Guid idSeat, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<SeatDto>>> GetSeatWithPaginationByAdminAsync(
            ViewSeatWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<SeatDto>> GetSeatByCodeAsync(string code, CancellationToken cancellationToken);

    }
}
