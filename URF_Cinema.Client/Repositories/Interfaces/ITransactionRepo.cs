using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
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
