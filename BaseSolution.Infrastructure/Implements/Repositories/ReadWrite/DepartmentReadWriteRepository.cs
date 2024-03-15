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
using static BaseSolution.Application.ValueObjects.Common.LocalizationString;

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
                var department_ = await GetDepartmentByIdAsync(request.Id, cancellationToken);

                // Update value to existed Department
                department_!.Deleted = true;
                department_.DeletedBy = request.DeletedBy;
                department_.DeletedTime = DateTimeOffset.UtcNow;

                _dbContext.DepartmentEntities.Update(department_);
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
                var department_ = await GetDepartmentByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Department
                department_!.Name = entity.Name;
                department_.Code = entity.Code;
                department_.Email = entity.Email;
                department_.PhoneNumber = entity.PhoneNumber;
                department_.AddressCode = entity.AddressCode;
                department_.AddressCodeFormat = entity.AddressCodeFormat;
                department_.Status = entity.Status;
                department_.ModifiedBy = entity.ModifiedBy;
                department_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.DepartmentEntities.Update(department_);
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
            var department_ = await _dbContext.DepartmentEntities.FirstOrDefaultAsync(c => c.Id == idDepartment && !c.Deleted, cancellationToken);

            return department_;
        }
    }
}
