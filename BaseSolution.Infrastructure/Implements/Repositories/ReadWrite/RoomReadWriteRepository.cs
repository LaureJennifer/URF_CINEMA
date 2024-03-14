using Azure.Core;
using BaseSolution.Application.DataTransferObjects.Room.Request;
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
                return RequestResult<Guid>.Fail(_localizationService["Unable to create Room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "Room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteRoomAsync(RoomDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed room
                var Room = await GetRoomByIdAsync(request.Id, cancellationToken);

                // Update value to existed room
                Room!.Deleted = true;
                Room.DeletedBy = request.DeletedBy;
                Room.DeletedTime = DateTimeOffset.UtcNow;

                _dbContext.RoomEntities.Remove(Room);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete Room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "Room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateRoomAsync(RoomEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed room
                var room = await GetRoomByIdAsync(entity.Id, cancellationToken);

                // Update value to existed room
                room!.Capacity= entity.Capacity;
                room.Code = entity.Code;
                room.SoundSystem = entity.SoundSystem;
                room.ScreenSize = entity.ScreenSize;
                room.RoomLayoutId = entity.RoomLayoutId;
                room.DepartmentId = entity.DepartmentId;
                room.Status = entity.Status;
                room.ModifiedBy = entity.ModifiedBy;
                room.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.RoomEntities.Update(room);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update Room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "Room"
                    }
                });
            }
        }
        private async Task<RoomEntity?> GetRoomByIdAsync(Guid idRoom, CancellationToken cancellationToken)
        {
            var room = await _dbContext.RoomEntities.FirstOrDefaultAsync(c => c.Id == idRoom && !c.Deleted, cancellationToken);

            return room;
        }
    }
}
