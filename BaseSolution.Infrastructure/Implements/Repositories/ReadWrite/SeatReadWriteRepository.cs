using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
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
                return RequestResult<Guid>.Fail(_localizationService["Unable to create seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "seat"
                    }
                });
            }
        }

        public async Task<RequestResult<List<Guid>>> CreateRangeSeatAsync(List<SeatEntity> requests, CancellationToken cancellationToken)
        {
            try
            {
                foreach(var entity in requests)
                {
                    entity.CreatedTime = DateTimeOffset.UtcNow;                   
                }

                await _dbContext.SeatEntities.AddRangeAsync(requests);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<List<Guid>>.Succeed(requests.Select(x=>x.Id).ToList());
            }
            catch (Exception e)
            {
                return RequestResult<List<Guid>>.Fail(_localizationService["Unable to create range seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "range seat"
                    }
                });
            }
        
        }

        public async Task<RequestResult<int>> DeleteSeatAsync(SeatDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Seat
                var seat_ = await GetSeatByIdAsync(request.Id, cancellationToken);

                // Update value to existed Seat
                seat_!.Deleted = true;
                seat_.DeletedBy = request.DeletedBy;
                seat_.DeletedTime = DateTimeOffset.UtcNow;
                seat_.Status = EntityStatus.Deleted;

            _dbContext.SeatEntities.Update(seat_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "seat"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateSeatAsync(SeatEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                // Get existed Seat
                var seat_ = await GetSeatByIdAsync(entity.Id, cancellationToken);

                // Update value to existed Seat
                seat_!.Code = string.IsNullOrWhiteSpace(entity.Code) ? seat_.Code : entity.Code;
                seat_.RoomLayoutId = entity.RoomLayoutId;
                seat_.SeatColumn = entity.SeatColumn;
                seat_.Row = entity.Row;
                seat_.Type = entity.Type;
                seat_.Price = entity.Price;
                seat_.Status = entity.Status;
                seat_.ModifiedBy = entity.ModifiedBy;
                seat_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.SeatEntities.Update(seat_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update seat"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "seat"
                    }
                });
            }
        }
        private async Task<SeatEntity?> GetSeatByIdAsync(Guid idSeat, CancellationToken cancellationToken)
        {
            var seat_ = await _dbContext.SeatEntities.FirstOrDefaultAsync(c => c.Id == idSeat && !c.Deleted, cancellationToken);

            return seat_;
        }
        
    }
}
