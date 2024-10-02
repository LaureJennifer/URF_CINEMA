using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface ITransactionReadWriteRepository
    {
        Task<RequestResult<Guid>> AddTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteTransactionAsync(TransactionDeleteRequest request, CancellationToken cancellationToken);
    }
}
