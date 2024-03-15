using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
    public class BillReadWriteRepository : IBillReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public BillReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }
        public async Task<RequestResult<Guid>> AddBillAsync(BillEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.BillEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create bill"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "bill"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteBillAsync(BillDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bill_ = await GetBillByIdAsync(request.Id, cancellationToken);

                bill_!.Deleted = true;
                bill_.DeletedBy = request.DeletedBy;
                bill_.DeletedTime = DateTimeOffset.UtcNow;
                bill_.Status = EntityStatus.Deleted;

                _dbContext.BillEntities.Update(bill_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete bill"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "bill"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateBillAsync(BillEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var bill_ = await GetBillByIdAsync(entity.Id, cancellationToken);

                bill_!.TotalPrice = entity.TotalPrice;
                bill_.TicketQuantity = entity.TicketQuantity;
                bill_.Status = entity.Status;
                bill_.ModifiedBy = entity.ModifiedBy;
                bill_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.BillEntities.Update(bill_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update bill"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "bill"
                    }
                });
            }
        }
        private async Task<BillEntity?> GetBillByIdAsync(Guid idBill, CancellationToken cancellationToken)
        {
            var bill_ = await _dbContext.BillEntities.FirstOrDefaultAsync(c => c.Id == idBill && !c.Deleted, cancellationToken);

            return bill_;
        }
    }
}
