using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadWrite
{
    public class TransactionReadWriteRepository : ITransactionReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public TransactionReadWriteRepository(AppReadWriteDbContext dbContext, ILocalizationService localizationService)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<Guid>> AddTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.TransactionEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create transaction"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "transaction"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteTransactionAsync(TransactionDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction_ = await GetTransactionByIdAsync(request.Id, cancellationToken);

                transaction_!.Deleted = true;
                transaction_.DeletedBy = request.DeletedBy;
                transaction_.DeletedTime = DateTimeOffset.UtcNow;
                transaction_.Status = EntityStatus.Deleted;

                _dbContext.TransactionEntities.Update(transaction_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete transaction"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "transaction"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateTransactionAsync(TransactionEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var transaction_ = await GetTransactionByIdAsync(entity.Id, cancellationToken);

                transaction_!.Price = entity.Price;
                transaction_.PaymentMethodId = entity.PaymentMethodId;
                transaction_.BillId = entity.BillId;
                transaction_.TransactionDate = entity.TransactionDate;
                transaction_.Status = entity.Status;
                transaction_.ModifiedBy = entity.ModifiedBy;
                transaction_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.TransactionEntities.Update(transaction_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update transaction"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "transaction"
                    }
                });
            }
        }
        private async Task<TransactionEntity?> GetTransactionByIdAsync(Guid idTransaction, CancellationToken cancellationToken)
        {
            var transaction_ = await _dbContext.TransactionEntities.FirstOrDefaultAsync(c => c.Id == idTransaction && !c.Deleted, cancellationToken);

            return transaction_;
        }
    }
}
