using BaseSolution.Application.DataTransferObjects.Seat.Request;
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
    public class SeatReadWriteRepository : ISeatReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public SeatReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<Guid>> AddSeatAsync(SeatEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.SeatEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create Seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "Seat"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteSeatAsync(SeatDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Seat
                var Seat = await GetSeatByIdAsync(request.Id, cancellationToken);

                // Update value to existed Seat
                Seat!.Deleted = true;
                Seat.DeletedBy = request.DeletedBy;
                Seat.DeletedTime = DateTimeOffset.UtcNow;

                _dbContext.SeatEntities.Remove(Seat);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete Seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "Seat"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateSeatAsync(SeatEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Seat
                var Seat = await GetSeatByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Seat
                Seat.Code = entity.Code;
                Seat.SeatPosition = entity.SeatPosition;
                Seat.Type = entity.Type;
                Seat.Price = entity.Price;
                Seat.RoomLayoutId = entity.RoomLayoutId;
                Seat.Status = entity.Status;
                Seat.ModifiedBy = entity.ModifiedBy;
                Seat.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.SeatEntities.Update(Seat);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update Seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "Seat"
                    }
                });
            }
        }
        private async Task<SeatEntity?> GetSeatByIdAsync(Guid idSeat, CancellationToken cancellationToken)
        {
            var Seat = await _dbContext.SeatEntities.FirstOrDefaultAsync(c => c.Id == idSeat && !c.Deleted, cancellationToken);

            return Seat;
        }
    }
}
