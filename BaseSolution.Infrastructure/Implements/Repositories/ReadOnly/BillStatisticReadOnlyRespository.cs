using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
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
using static BaseSolution.Application.ValueObjects.Common.LocalizationString;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class BillStatisticReadOnlyRespository : IBillStatisticReadOnlyRespository
    {
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public BillStatisticReadOnlyRespository(AppReadOnlyDbContext dbContext, ILocalizationService localizationService, IMapper mapper)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async Task<RequestResult<List<BillStatisticForMonthDto>>> GetBillStasticForMonthAsync(BillStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.BillEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<BillStatisticForMonthDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<BillStatisticForMonthDto> billStatistics = query.Data!.ToList();

                List<BillStatisticForMonthDto> totalAmountForMonth = null;


                if (billStatistics != null)
                {

                    totalAmountForMonth = billStatistics
                            .GroupBy(x => new { x.Month, x.Year,x.DepartmentName })
                            .Select(g => new BillStatisticForMonthDto
                            {
                                Month = g.Key.Month,
                                Year = g.Key.Year,
                                DepartmentName = g.Key.DepartmentName,
                                Revenue = g.Sum(x => x.Revenue)
                            }).ToList();

                }
                return RequestResult<List<BillStatisticForMonthDto>>.Succeed(totalAmountForMonth);

            }
            catch (Exception e)
            {

                return RequestResult<List<BillStatisticForMonthDto>>.Fail(_localizationService["Bill statistic for month is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "bill statistic for month"
                    }
                });
            }
        }

        public async Task<RequestResult<List<BillStatisticForQuarterDto>>> GetBillStasticForQuarterAsync(BillStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.BillEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<BillStatisticForQuarterDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<BillStatisticForQuarterDto> billStatistics = query.Data!.ToList();

                List<BillStatisticForQuarterDto> totalAmountForQuarter = null;

                if (billStatistics != null)
                {

                    totalAmountForQuarter = billStatistics
                            .GroupBy(x => new { x.Quarter, x.Year })
                            .Select(g => new BillStatisticForQuarterDto
                            {
                                Quarter = g.Key.Quarter,
                                Year = g.Key.Year,
                                Revenue = g.Sum(x => x.Revenue)
                            }).ToList();

                }
                return RequestResult<List<BillStatisticForQuarterDto>>.Succeed(totalAmountForQuarter);

            }
            catch (Exception e)
            {

                return RequestResult<List<BillStatisticForQuarterDto>>.Fail(_localizationService["Bill statistic for quarter is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "bill statistic for quarter"
                    }
                });
            }
        }

        public async Task<RequestResult<List<BillStatisticForYearDto>>> GetBillStasticForYearAsync(BillStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.BillEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<BillStatisticForYearDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<BillStatisticForYearDto> billStatistics = query.Data!.ToList();

                List<BillStatisticForYearDto> totalAmountForYear = null;

                if (billStatistics != null)
                {

                    totalAmountForYear = billStatistics.GroupBy(x => x.Year)
                                   .Select(g => new BillStatisticForYearDto
                                   {
                                       Year = g.Key,
                                       Revenue = g.Sum(x => x.Revenue)
                                   }).ToList();

                }
                return RequestResult<List<BillStatisticForYearDto>>.Succeed(totalAmountForYear);

            }
            catch (Exception e)
            {

                return RequestResult<List<BillStatisticForYearDto>>.Fail(_localizationService["Bill statistic for year is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "bill statistic for year"
                    }
                });
            }
        }
    }
}
