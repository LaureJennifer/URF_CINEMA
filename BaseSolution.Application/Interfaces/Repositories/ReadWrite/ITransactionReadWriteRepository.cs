using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Transaction.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface ITransactionReadWriteRepository
    {
        Task<RequestResult<Guid>> AddTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteTransactionAsync(TransactionDeleteRequest request, CancellationToken cancellationToken);
    }
}
