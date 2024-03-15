using BaseSolution.Application.DataTransferObjects.Role.Request;
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
    public class RoleReadWriteRepository :IRoleReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public RoleReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddRoleAsync(RoleEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.Now;

                await _dbContext.RoleEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {

                return RequestResult<Guid>.Fail(_localizationService["Unable to create role"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "role"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteRoleAsync(RoleDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await GetRoleByIdAsync(request.Id, cancellationToken);

                role!.Deleted = true;
                role.DeletedTime = DateTimeOffset.Now;
                role.Status = EntityStatus.Deleted;

                _dbContext.RoleEntities.Update(role);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {

                return RequestResult<int>.Fail(_localizationService["Unable to delete role"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "role"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateRoleAsync(RoleEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var role = await GetRoleByIdAsync(entity.Id, cancellationToken);

                role!.Code = string.IsNullOrEmpty(entity.Code) ? role.Code : entity.Code;
                role!.Status = entity.Status == EntityStatus.Active ? EntityStatus.Active : EntityStatus.InActive;
                role.ModifiedBy = entity.ModifiedBy;
                role.ModifiedTime = DateTimeOffset.Now;

                _dbContext.RoleEntities.Update(role);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {

                return RequestResult<int>.Fail(_localizationService["Unable to update role"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "role"
                    }
                });
            }
        }
        private async Task<RoleEntity?> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken)
        {
            var role_ = await _dbContext.RoleEntities.FirstOrDefaultAsync(c => c.Id == idRole && !c.Deleted, cancellationToken);

            return role_;
        }
    }
}
