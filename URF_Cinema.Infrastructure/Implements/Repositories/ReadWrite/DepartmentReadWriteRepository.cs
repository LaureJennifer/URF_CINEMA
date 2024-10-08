﻿using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using static URF_Cinema.Application.ValueObjects.Common.LocalizationString;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadWrite
{
    public class DepartmentReadWriteRepository : IDepartmentReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public DepartmentReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<Guid>> AddDepartmentAsync(DepartmentEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;
                entity.Status = EntityStatus.Active;
                await _dbContext.DepartmentEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "department"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteDepartmentAsync(DepartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Department
                var department_ = await GetDepartmentByIdAsync(request.Id, cancellationToken);

                // Update value to existed Department
                department_!.Deleted = true;
                department_.DeletedBy = request.DeletedBy;
                department_.DeletedTime = DateTimeOffset.UtcNow;
                department_.Status = EntityStatus.Deleted;

                _dbContext.DepartmentEntities.Update(department_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "department"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateDepartmentAsync(DepartmentEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Department
                var department_ = await GetDepartmentByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Department
                department_!.Name = string.IsNullOrWhiteSpace(entity.Name) ? department_.Name : entity.Name;
                department_.Code = string.IsNullOrWhiteSpace(entity.Code) ? department_.Code : entity.Code;
                department_.Email = string.IsNullOrWhiteSpace(entity.Email) ? department_.Email : entity.Email;
                department_.PhoneNumber = string.IsNullOrWhiteSpace(entity.PhoneNumber) ? department_.PhoneNumber : entity.PhoneNumber;
                department_.Address = string.IsNullOrWhiteSpace(entity.Address) ? department_.Address : entity.Address;
                department_.AddressCode = string.IsNullOrWhiteSpace(entity.AddressCode) ? department_.AddressCode : entity.AddressCode;
                department_.Status = entity.Status == EntityStatus.InActive ? EntityStatus.InActive : entity.Status;
                department_.ModifiedBy = entity.ModifiedBy;
                department_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.DepartmentEntities.Update(department_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "department"
                    }
                });
            }
        }
        private async Task<DepartmentEntity?> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            var department_ = await _dbContext.DepartmentEntities.FirstOrDefaultAsync(c => c.Id == idDepartment && !c.Deleted, cancellationToken);

            return department_;
        }
    }
}
