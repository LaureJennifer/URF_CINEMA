using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TicketReadOnlyRepository : ITicketReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly AppReadWriteDbContext _appReadWriteDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public TicketReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, AppReadWriteDbContext appReadWriteDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _appReadWriteDbContext = appReadWriteDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<TicketDto?>> GetTicketByIdAsync(Guid idTicket, CancellationToken cancellationToken)
        {
            try
            {
                var ticket = await _appReadOnlyDbContext.TicketEntities.AsNoTracking().Where(x => x.Id == idTicket).ProjectTo<TicketDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<TicketDto?>.Succeed(ticket);

            }
            catch (Exception e)
            {

                return RequestResult<TicketDto?>.Fail(_localizationService["Ticket is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "ticket"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<TicketDto>>> GetTicketWithPaginationByAdminAsync(ViewTicketWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var tickets = _appReadOnlyDbContext.TicketEntities.AsNoTracking().ProjectTo<TicketDto>(_mapper.ConfigurationProvider);

                if (request.BillId != null)
                {
                    tickets = tickets.Where(x => x.BillId == request.BillId);
                }
                if (!string.IsNullOrWhiteSpace(request.FilmName))
                {
                    tickets = tickets.Where(x => x.FilmName.ToLower().Contains(request.FilmName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    tickets = tickets.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                var result = await tickets.Where(x => x.Status != EntityStatus.InActive).PaginateAsync(request, cancellationToken);
                foreach (var ticket in tickets)
                {
                    var createTime = ticket.CreatedTime;

                    // Find bill to map TicketQuantity and TotalPrice then update database
                    var ticketEntity_ = _appReadWriteDbContext.TicketEntities.FirstOrDefault(c => c.Id == ticket.Id);
                    ticketEntity_!.CreatedTime = createTime;

                    _appReadWriteDbContext.TicketEntities.Update(ticketEntity_);

                }
                await _appReadWriteDbContext.SaveChangesAsync();

                return RequestResult<PaginationResponse<TicketDto>>.Succeed(new PaginationResponse<TicketDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<TicketDto>>.Fail(_localizationService["List of ticket are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of ticket"
                    }
                });
            }
        }
    }
}
