using URF_Cinema.Application.DataTransferObjects.Room.Request;
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
    public class RoomReadWriteRepository : IRoomReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;
        public RoomReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<Guid>> AddRoomAsync(RoomEntity entity, CancellationToken cancellationToken)
        {

            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.RoomEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteRoomAsync(RoomDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed room
                var room_ = await GetRoomByIdAsync(request.Id, cancellationToken);

                // Update value to existed room
                room_!.Deleted = true;
                room_.DeletedBy = request.DeletedBy;
                room_.DeletedTime = DateTimeOffset.UtcNow;
                room_.Status = EntityStatus.Deleted;

                _dbContext.RoomEntities.Update(room_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateRoomAsync(RoomEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed room
                var room_ = await GetRoomByIdAsync(entity.Id, cancellationToken);

                // Update value to existed room
                room_!.Capacity= entity.Capacity;
                room_.Code = string.IsNullOrWhiteSpace(entity.Code) ? room_.Code : entity.Code;
                room_.SoundSystem = entity.SoundSystem;
                room_.ScreenSize = entity.ScreenSize;
                room_.Status = entity.Status;
                room_.ModifiedBy = entity.ModifiedBy;
                room_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.RoomEntities.Update(room_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "room"
                    }
                });
            }
        }
        private async Task<RoomEntity?> GetRoomByIdAsync(Guid idRoom, CancellationToken cancellationToken)
        {
            var room_ = await _dbContext.RoomEntities.FirstOrDefaultAsync(c => c.Id == idRoom && !c.Deleted, cancellationToken);

            return room_;
        }
    }
}
