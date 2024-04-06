using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CreateSeatReadOnlyRepository : ICreateSeatReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CreateSeatReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<List<SeatDto>>> GetListSeatByIdAsync(List<Guid> idSeat, CancellationToken cancellationToken)
        {
            try
            {
                List<SeatDto> listSeat = new();
                foreach (var item in idSeat)
                {
                    var major = await _appReadOnlyDbContext.SeatEntities.AsNoTracking().Where(c => c.Id == item && !c.Deleted).ProjectTo<SeatDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
                    listSeat.Add(major);
                }
                return RequestResult<List<SeatDto>>.Succeed(listSeat);
            }
            catch (Exception e)
            {
                return RequestResult<List<SeatDto>>.Fail(_localizationService["Seat is not found"], new[]
                {
                new ErrorItem
                {
                    Error = e.Message,
                    FieldName = LocalizationString.Common.FailedToGet + "seat"
                }
            });
            }
        }
        
    }
}
