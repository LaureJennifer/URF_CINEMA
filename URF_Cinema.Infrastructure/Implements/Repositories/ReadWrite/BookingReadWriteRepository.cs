﻿using URF_Cinema.Application.DataTransferObjects.Booking.Request;
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
    public class BookingReadWriteRepository:IBookingReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public BookingReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddBookingAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            try
            {               

                await _dbContext.BookingEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create booking"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "booking"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteBookingAsync(BookingDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var booking_ = await GetBookingByIdAsync(request.Id, cancellationToken);
                
                booking_!.Deleted = true;
                booking_.DeletedTime = DateTimeOffset.UtcNow;
                booking_.SeatStatus = EntityStatus.Deleted;

                _dbContext.BookingEntities.Update(booking_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete booking"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "booking"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateBookingAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var booking_ = await GetBookingByIdAsync(entity.Id, cancellationToken);
                booking_!.SeatStatus = entity.SeatStatus;
                booking_.ModifiedBy = entity.ModifiedBy;
                booking_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.BookingEntities.Update(booking_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update booking"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "booking"
                    }
                });
            }
        }
        private async Task<BookingEntity?> GetBookingByIdAsync(Guid idBill, CancellationToken cancellationToken)
        {
            var booking_ = await _dbContext.BookingEntities.FirstOrDefaultAsync(c => c.Id == idBill && !c.Deleted, cancellationToken);

            return booking_;
        }
    }
}
