using URF_Cinema.Application.DataTransferObjects.User.Request;
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

        public async Task<RequestResult<int>> DeleteUserAsync(UserDeleteRequest request, CancellationToken cancellationToken)
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

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete user"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "user"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateUserAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var user_ = await GetUserByIdAsync(entity.Id, cancellationToken);

                user_!.Email = string.IsNullOrWhiteSpace(entity.Email) ? user_.Email : entity.Email;
                user_.Name = string.IsNullOrWhiteSpace(entity.Name) ? user_.Name : entity.Name;
                user_.PassWord = string.IsNullOrWhiteSpace(entity.PassWord) ? user_.PassWord : entity.PassWord;
                user_.UrlImage = string.IsNullOrWhiteSpace(entity.UrlImage) ? user_.UrlImage : entity.UrlImage;
                user_.PhoneNumber= string.IsNullOrWhiteSpace(entity.PhoneNumber) ? user_.PhoneNumber : entity.PhoneNumber;
                user_.Status = entity.Status;
                user_.ModifiedBy = entity.ModifiedBy;
                user_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.UserEntities.Update(user_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update user"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "user"
                    }
                });
            }
        }
        private async Task<UserEntity?> GetUserByIdAsync(Guid idUser, CancellationToken cancellationToken)
        {
            var user_ = await _dbContext.UserEntities.FirstOrDefaultAsync(c => c.Id == idUser && !c.Deleted, cancellationToken);

            return user_;
        }
    }
}
