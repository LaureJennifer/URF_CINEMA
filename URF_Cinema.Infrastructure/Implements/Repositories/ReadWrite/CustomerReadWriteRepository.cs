﻿using URF_Cinema.Application.DataTransferObjects.Customer.Request;
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
    public class CustomerReadWriteRepository : ICustomerReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public CustomerReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<Guid>> AddCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.CustomerEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "customer"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteCustomerAsync(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Customer
                var customer_ = await GetCustomerByIdAsync(request.Id, cancellationToken);

                // Update value to existed Customer
                customer_!.Deleted = true;
                customer_.DeletedBy = request.DeletedBy;
                customer_.DeletedTime = DateTimeOffset.UtcNow;
                customer_.Status = EntityStatus.Deleted;

                _dbContext.CustomerEntities.Update(customer_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "customer"
                    }
                });
            }
        }

        public async Task<RequestResult<Guid>> RegisterCustomerAsync(CustomerEntity request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.CustomerEntities.FirstOrDefaultAsync(c => c.Email.ToUpper() == request.Email.ToUpper() && c.PassWord == request.PassWord && !c.Deleted);
                request.CreatedTime = DateTimeOffset.UtcNow;
                
                await _dbContext.CustomerEntities.AddAsync(request);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(request.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to register customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "customer"
                    }
                });
            }
        }

        public async Task<RequestResult<Guid>> ResetPasswordCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.CustomerEntities.FirstOrDefaultAsync(c => c.Id == entity.Id && !c.Deleted);
                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to reset customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "customer"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Customer
                var customer_ = await GetCustomerByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Customer
                customer_!.Name = string.IsNullOrWhiteSpace(entity.Name) ? customer_.Name : entity.Name;
                customer_.PassWord = string.IsNullOrWhiteSpace(entity.PassWord) ? customer_.PassWord : entity.PassWord;
                customer_.PhoneNumber = entity.PhoneNumber;
                customer_.Email = string.IsNullOrWhiteSpace(entity.Email) ? customer_.Email : entity.Email;
                customer_.Status = entity.Status;
                customer_.ModifiedBy = entity.ModifiedBy;
                customer_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.CustomerEntities.Update(customer_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "customer"
                    }
                });
            }
        }
        private async Task<CustomerEntity?> GetCustomerByIdAsync(Guid idCustomer, CancellationToken cancellationToken)
        {
            var customer_ = await _dbContext.CustomerEntities.FirstOrDefaultAsync(c => c.Id == idCustomer && !c.Deleted, cancellationToken);

            return customer_;
        }
    }
}
