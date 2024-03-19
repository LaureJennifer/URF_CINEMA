using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
    public class RoomLayoutReadWriteRepository : IRoomLayoutReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public RoomLayoutReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.RoomLayoutEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create room layout"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "room layout"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteRoomLayoutAsync(RoomLayoutDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var roomLayout_ = await GetRoomLayoutByIdAsync(request.Id, cancellationToken);

                roomLayout_!.Deleted = true;
                roomLayout_.DeletedBy = request.DeletedBy;
                roomLayout_.DeletedTime = DateTimeOffset.UtcNow;

                _dbContext.RoomLayoutEntities.Update(roomLayout_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete room layout"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "room layout"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateRoomLayoutAsync(RoomLayoutEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var roomLayout_ = await GetRoomLayoutByIdAsync(entity.Id, cancellationToken);

                roomLayout_!.Name = entity.Name;
                roomLayout_.Status = entity.Status;
                roomLayout_.ModifiedBy = entity.ModifiedBy;
                roomLayout_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.RoomLayoutEntities.Update(roomLayout_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update room layout"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "room layout"
                    }
                });
            }
        }
        private async Task<RoomLayoutEntity?> GetRoomLayoutByIdAsync(Guid idRoomLayout_, CancellationToken cancellationToken)
        {
            var roomLayout_ = await _dbContext.RoomLayoutEntities.FirstOrDefaultAsync(c => c.Id == idRoomLayout_ && !c.Deleted, cancellationToken);

            return roomLayout_;
        }
    }
}
