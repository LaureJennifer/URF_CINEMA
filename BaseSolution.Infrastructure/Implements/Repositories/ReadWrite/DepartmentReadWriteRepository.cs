using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
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

                await _dbContext.DepartmentEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create Department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "Department"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteDepartmentAsync(DepartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Department
                var Department = await GetDepartmentByIdAsync(request.Id, cancellationToken);

                // Update value to existed Department
                Department!.Deleted = true;
                Department.DeletedBy = request.DeletedBy;
                Department.DeletedTime = DateTimeOffset.UtcNow;

                _dbContext.DepartmentEntities.Remove(Department);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete Department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "Department"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateDepartmentAsync(DepartmentEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Department
                var Department = await GetDepartmentByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Department
                Department!.Name = entity.Name;
                Department.Code = entity.Code;
                Department.Email = entity.Email;
                Department.PhoneNumber = entity.PhoneNumber;
                Department.AddressCode = entity.AddressCode;
                Department.AddressCodeFormat = entity.AddressCodeFormat;
                Department.Status = entity.Status;
                Department.ModifiedBy = entity.ModifiedBy;
                Department.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.DepartmentEntities.Update(Department);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update Department"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "Department"
                    }
                });
            }
        }
        private async Task<DepartmentEntity?> GetDepartmentByIdAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            var Department = await _dbContext.DepartmentEntities.FirstOrDefaultAsync(c => c.Id == idDepartment && !c.Deleted, cancellationToken);

            return Department;
        }
    }
}
