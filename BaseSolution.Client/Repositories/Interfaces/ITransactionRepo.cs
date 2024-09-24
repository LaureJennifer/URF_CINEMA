using BaseSolution.Application.DataTransferObjects.Transaction.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Application.DataTransferObjects.Transaction;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface ITransactionRepo
    {
        public Task<bool> AddAsync(TransactionCreateRequest request);
        public Task<RequestResult<TransactionDeleteRequest>> RemoveAsync(TransactionDeleteRequest request);
        public Task<bool> UpdateAsync(TransactionUpdateRequest request);
        public Task<RequestResult<TransactionDto>> GetByIdAsync(Guid id);
        public Task<TransactionListWithPaginationViewModel> GetAllActive(ViewTransactionWithPaginationRequest request);
    }
}
