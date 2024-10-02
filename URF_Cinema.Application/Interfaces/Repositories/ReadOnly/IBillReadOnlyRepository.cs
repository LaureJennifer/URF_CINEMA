using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBillReadOnlyRepository
    {
        Task<RequestResult<BillDto?>> GetBillByIdAsync(Guid idBill, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<BillDto>>> GetBillWithPaginationByAdminAsync(
            ViewBillWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
