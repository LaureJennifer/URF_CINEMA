using URF_Cinema.Application.DataTransferObjects.Ticket.Request;
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
    public class TicketReadWriteRepository : ITicketReadWriteRepository
    {
        private readonly AppReadWriteDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public TicketReadWriteRepository(AppReadWriteDbContext dbContext, ILocalizationService localizationService)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<Guid>> AddTicketAsync(TicketEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.TicketEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create ticket"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "ticket"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteTicketAsync(TicketDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ticket_ = await GetTicketByIdAsync(request.Id, cancellationToken);

                ticket_!.Deleted = true;
                ticket_.DeletedBy = request.DeletedBy;
                ticket_.DeletedTime = DateTimeOffset.UtcNow;
                ticket_.Status = EntityStatus.Deleted;

                _dbContext.TicketEntities.Update(ticket_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete ticket"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "ticket"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateTicketAsync(TicketEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var ticket_ = await GetTicketByIdAsync(entity.Id, cancellationToken);

                ticket_!.Code = string.IsNullOrWhiteSpace(entity.Code) ? ticket_.Code : entity.Code; ;
                //ticket_.FilmId = entity.FilmId;
                ticket_.BookingId = entity.BookingId;
                //ticket_.BillId = entity.BillId;
                ticket_.Status = entity.Status;
                ticket_.ModifiedBy = entity.ModifiedBy;
                ticket_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.TicketEntities.Update(ticket_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update ticket"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "ticket"
                    }
                });
            }
        }
        private async Task<TicketEntity?> GetTicketByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken)
        {
            var ticket_ = await _dbContext.TicketEntities.FirstOrDefaultAsync(c => c.Id == idPaymentMethod && !c.Deleted, cancellationToken);

            return ticket_;
        }
    }
}
