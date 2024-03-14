using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
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
                var Customer = await GetCustomerByIdAsync(request.Id, cancellationToken);

                // Update value to existed Customer
                Customer!.Deleted = true;
                Customer.DeletedBy = request.DeletedBy;
                Customer.DeletedTime = DateTimeOffset.UtcNow;
                Customer.Status = EntityStatus.Deleted;

                _dbContext.CustomerEntities.Remove(Customer);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete Customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "Customer"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Customer
                var Customer = await GetCustomerByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Customer
                Customer!.Name = string.IsNullOrWhiteSpace(entity.Name) ? Customer.Name : entity.Name;
                Customer.PhoneNumber = entity.PhoneNumber;
                Customer.Email = string.IsNullOrWhiteSpace(entity.Email) ? Customer.Email : entity.Email;
                Customer.Status = entity.Status;
                Customer.ModifiedBy = entity.ModifiedBy;
                Customer.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.CustomerEntities.Update(Customer);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update Customer"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "Customer"
                    }
                });
            }
        }
        private async Task<CustomerEntity?> GetCustomerByIdAsync(Guid idCustomer, CancellationToken cancellationToken)
        {
            var Customer = await _dbContext.CustomerEntities.FirstOrDefaultAsync(c => c.Id == idCustomer && !c.Deleted, cancellationToken);

            return Customer;
        }
    }
}
