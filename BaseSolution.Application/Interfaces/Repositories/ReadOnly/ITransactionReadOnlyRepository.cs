using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.Transaction;
using BaseSolution.Application.DataTransferObjects.Transaction.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITransactionReadOnlyRepository
    {
        Task<RequestResult<TransactionDto?>> GetTransactionByIdAsync(Guid idTransaction, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<TransactionDto>>> GetTransactionWithPaginationByAdminAsync(
            ViewTransactionWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
