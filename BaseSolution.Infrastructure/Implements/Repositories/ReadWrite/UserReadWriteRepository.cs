using BaseSolution.Application.DataTransferObjects.User.Request;
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
    public class UserReadWriteRepository : IUserReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public UserReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddUserAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.UserEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create user"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "user"
                    }
                });
            }
        }

        public async Task<RequestResult<bool>> DeleteUserAsync(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user_ = await GetUserByIdAsync(request.Id, cancellationToken);

                user_!.Deleted = true;
                user_.DeletedBy = request.DeletedBy;
                user_.DeletedTime = DateTimeOffset.UtcNow;
                user_.Status = EntityStatus.Deleted;

                _dbContext.UserEntities.Update(user_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to delete user"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "user"
                    }
                });
            }
        }

        public async Task<RequestResult<bool>> UpdateUserAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var user_ = await GetUserByIdAsync(entity.Id, cancellationToken);

                user_!.Email = string.IsNullOrWhiteSpace(entity.Email) ? user_.Email : entity.Email;
                user_.UrlImage = string.IsNullOrWhiteSpace(entity.UrlImage) ? user_.UrlImage : entity.UrlImage;
                user_.PhoneNumber= string.IsNullOrWhiteSpace(entity.PhoneNumber) ? user_.PhoneNumber : entity.PhoneNumber;
                user_.Status = entity.Status;
                user_.ModifiedBy = entity.ModifiedBy;
                user_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.UserEntities.Update(user_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to update film"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "film"
                    }
                });
            }
        }
        private async Task<UserEntity?> GetUserByIdAsync(Guid idUser, CancellationToken cancellationToken)
        {
            var example = await _dbContext.UserEntities.FirstOrDefaultAsync(c => c.Id == idUser && !c.Deleted, cancellationToken);

            return example;
        }
    }
}
