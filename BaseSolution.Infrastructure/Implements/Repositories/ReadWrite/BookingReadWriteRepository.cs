using BaseSolution.Application.DataTransferObjects.Booking.Request;
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
    public class BookingReadWriteRepository:IBookingReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public BookingReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public Task<RequestResult<Guid>> AddBookingAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResult<int>> DeleteBookingAsync(BookingDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var booking_ = await GetBookingByIdAsync(request.Id, cancellationToken);

                booking_!.Deleted = true;
                booking_.DeletedBy = request.DeletedBy;
                booking_.DeletedTime = DateTimeOffset.UtcNow;
                booking_.SeatStatus = EntityStatus.Available;

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

        public Task<RequestResult<int>> UpdateBookingAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private async Task<BookingEntity?> GetBookingByIdAsync(Guid idBill, CancellationToken cancellationToken)
        {
            var booking_ = await _dbContext.BookingEntities.FirstOrDefaultAsync(c => c.Id == idBill && !c.Deleted, cancellationToken);

            return booking_;
        }
    }
}
