using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmStatisticReadOnlyRespository : IFilmStatisticReadOnlyRespository
    {
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmStatisticReadOnlyRespository(AppReadOnlyDbContext dbContext, ILocalizationService localizationService, IMapper mapper)
        {
            _dbContext = dbContext;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public async Task<RequestResult<List<FilmStatisticForMonthDto>>> GetFilmStatisticForMonthAsync(FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.TicketEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmStatisticForMonthDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<FilmStatisticForMonthDto> FilmStatistics = query.Data!.ToList();

                List<FilmStatisticForMonthDto> totalQuantityForMonth = null;


                if (FilmStatistics != null)
                {

                    totalQuantityForMonth = FilmStatistics
                            .GroupBy(x => new { x.Month, x.Year, x.DepartmentName,x.FilmName })
                            .Select(g => new FilmStatisticForMonthDto
                            {
                                Month = g.Key.Month,
                                Year = g.Key.Year,
                                DepartmentName = g.Key.DepartmentName,
                                FilmName = g.Key.FilmName,
                                Views = g.Sum(x => x.Views)
                            }).ToList();

                }
                return RequestResult<List<FilmStatisticForMonthDto>>.Succeed(totalQuantityForMonth);

            }
            catch (Exception e)
            {

                return RequestResult<List<FilmStatisticForMonthDto>>.Fail(_localizationService["Film statistic for month is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "film statistic for month"
                    }
                });
            }
        }

        public async Task<RequestResult<List<FilmStatisticForQuarterDto>>> GetFilmStatisticForQuarterAsync(FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.TicketEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmStatisticForQuarterDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<FilmStatisticForQuarterDto> filmStatistics = query.Data!.ToList();

                List<FilmStatisticForQuarterDto> totalQuantityForQuarter = null;

                if (filmStatistics != null)
                {

                    totalQuantityForQuarter = filmStatistics
                            .GroupBy(x => new { x.Quarter, x.Year, x.DepartmentName, x.FilmName })
                            .Select(g => new FilmStatisticForQuarterDto
                            {
                                Quarter = g.Key.Quarter,
                                Year = g.Key.Year,
                                DepartmentName = g.Key.DepartmentName,
                                FilmName = g.Key.FilmName,
                                Views = g.Sum(x => x.Views)
                            }).ToList();

                }
                return RequestResult<List<FilmStatisticForQuarterDto>>.Succeed(totalQuantityForQuarter);

            }
            catch (Exception e)
            {

                return RequestResult<List<FilmStatisticForQuarterDto>>.Fail(_localizationService["Film statistic for quarter is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "film statistic for quarter"
                    }
                });
            }
        }

        public async Task<RequestResult<List<FilmStatisticForYearDto>>> GetFilmStatisticForYearAsync(FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _dbContext.TicketEntities.Where(x => x.Status != EntityStatus.Deleted).ProjectTo<FilmStatisticForYearDto>(_mapper.ConfigurationProvider).PaginateAsync(request, cancellationToken);

                List<FilmStatisticForYearDto> filmStatistics = query.Data!.ToList();

                List<FilmStatisticForYearDto> totalQuantityForYear = null;

                if (filmStatistics != null)
                {

                    totalQuantityForYear = filmStatistics.GroupBy(x => new { x.Year,x.DepartmentName, x.FilmName })
                                   .Select(g => new FilmStatisticForYearDto
                                   {
                                       Year = g.Key.Year,
                                       DepartmentName = g.Key.DepartmentName,
                                       FilmName = g.Key.FilmName,
                                       Views = g.Sum(x => x.Views)
                                   }).ToList();

                }
                return RequestResult<List<FilmStatisticForYearDto>>.Succeed(totalQuantityForYear);

            }
            catch (Exception e)
            {

                return RequestResult<List<FilmStatisticForYearDto>>.Fail(_localizationService["Film statistic for year is not found"], new[]
                    {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "film statistic for year"
                    }
                });
            }
        }
    }
}
