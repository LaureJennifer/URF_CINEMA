﻿using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
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
    public class PaymentMethodReadWriteRepository : IPaymentMethodReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public PaymentMethodReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddPaymentMethodAsync(PaymentMethodEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.PaymentMethodEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create payment method"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "payment method"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeletePaymentMethodAsync(PaymentMethodDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed PaymentMethod
                var paymentMethod_ = await GetPaymentMethodByIdAsync(request.Id, cancellationToken);

                // Update value to existed PaymentMethod
                paymentMethod_!.Deleted = true;
                paymentMethod_.DeletedBy = request.DeletedBy;
                paymentMethod_.DeletedTime = DateTimeOffset.UtcNow;
                paymentMethod_.Status = EntityStatus.Deleted;

                _dbContext.PaymentMethodEntities.Update(paymentMethod_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete payment method"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "payment method"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdatePaymentMethodAsync(PaymentMethodEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Seat
                var paymentMethod_ = await GetPaymentMethodByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Seat
                paymentMethod_!.Name = string.IsNullOrWhiteSpace(entity.Name) ? paymentMethod_.Name : entity.Name;
                paymentMethod_.Description = entity.Description;
                paymentMethod_.Status = entity.Status;
                paymentMethod_.ModifiedBy = entity.ModifiedBy;
                paymentMethod_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.PaymentMethodEntities.Update(paymentMethod_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update payment method"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "payment method"
                    }
                });
            }
        }
        private async Task<PaymentMethodEntity?> GetPaymentMethodByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken)
        {
            var paymentMethod_ = await _dbContext.PaymentMethodEntities.FirstOrDefaultAsync(c => c.Id == idPaymentMethod && !c.Deleted, cancellationToken);

            return paymentMethod_;
        }
    }
}
