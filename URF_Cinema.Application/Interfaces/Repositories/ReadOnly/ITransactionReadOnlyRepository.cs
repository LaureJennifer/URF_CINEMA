using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITransactionReadOnlyRepository
    {
        Task<RequestResult<TransactionDto?>> GetTransactionByIdAsync(Guid idTransaction, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<TransactionDto>>> GetTransactionWithPaginationByAdminAsync(
            ViewTransactionWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
