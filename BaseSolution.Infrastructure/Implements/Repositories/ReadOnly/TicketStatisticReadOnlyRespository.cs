using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TicketStatisticReadOnlyRespository : ITicketStatisticReadOnlyRespository
    {
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public TicketStatisticReadOnlyRespository(AppReadOnlyDbContext dbContext, ILocalizationService localizationService, IMapper mapper)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async Task<RequestResult<List<TicketStatisticForMonthDto>>> GetTicketStasticForMonthAsync(TicketStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.BillEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<TicketStatisticForMonthDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<TicketStatisticForMonthDto> ticketStatistics = query.Data!.ToList();

                List<TicketStatisticForMonthDto> totalQuantityForMonth = null;

                if (ticketStatistics != null)
                {

                    totalQuantityForMonth = ticketStatistics
                            .GroupBy(x => new { x.Month, x.Year, x.DepartmentName })
                            .Select(g => new TicketStatisticForMonthDto
                            {
                                Month = g.Key.Month,
                                Year = g.Key.Year,
                                DepartmentName = g.Key.DepartmentName,
                                Quantity = g.Sum(x => x.Quantity)
                            }).ToList();

                }
                return RequestResult<List<TicketStatisticForMonthDto>>.Succeed(totalQuantityForMonth);

            }
            catch (Exception e)
            {

                return RequestResult<List<TicketStatisticForMonthDto>>.Fail(_localizationService["Ticket statistic for month is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "ticket statistic for month"
                    }
                });
            }
        }

        public async Task<RequestResult<List<TicketStatisticForQuarterDto>>> GetTicketStasticForQuarterAsync(TicketStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.BillEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<TicketStatisticForQuarterDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<TicketStatisticForQuarterDto> ticketStatistics = query.Data!.ToList();

                List<TicketStatisticForQuarterDto> totalQuantityForQuarter = null;

                if (ticketStatistics != null)
                {

                    totalQuantityForQuarter = ticketStatistics
                            .GroupBy(x => new { x.Quarter, x.Year, x.DepartmentName })
                            .Select(g => new TicketStatisticForQuarterDto
                            {
                                Quarter = g.Key.Quarter,
                                Year = g.Key.Year,
                                DepartmentName = g.Key.DepartmentName,
                                Quantity = g.Sum(x => x.Quantity)
                            }).ToList();

                }
                return RequestResult<List<TicketStatisticForQuarterDto>>.Succeed(totalQuantityForQuarter);

            }
            catch (Exception e)
            {

                return RequestResult<List<TicketStatisticForQuarterDto>>.Fail(_localizationService["Ticket statistic for quarter is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "ticket statistic for quarter"
                    }
                });
            }
        }
    }
}
