using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Seat;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class SeatReadOnlyRepository : ISeatReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public SeatReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<SeatDto?>> GetSeatByIdAsync(Guid idSeat, CancellationToken cancellationToken)
        {
            try
            {
                var seat = await _appReadOnlyDbContext.SeatEntities.AsNoTracking().Where(x => x.Id == idSeat).ProjectTo<SeatDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<SeatDto?>.Succeed(seat);

            }
            catch (Exception e)
            {

                return RequestResult<SeatDto?>.Fail(_localizationService["Seat is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Seat"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<SeatDto>>> GetSeatWithPaginationByAdminAsync(ViewSeatWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var seats = _appReadOnlyDbContext.SeatEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<SeatDto>(_mapper.ConfigurationProvider);
                if (request.RoomLayoutId != null)
                {
                    seats = seats.Where(x => x.RoomLayoutId == request.RoomLayoutId);
                }
                if (!string.IsNullOrWhiteSpace(request.RoomLayoutName))
                {
                    seats = seats.Where(x => x.RoomLayoutName.ToLower().Contains(request.RoomLayoutName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    seats = seats.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                if (request.Type!=null)
                {
                    seats = seats.Where(x => x.Type==request.Type);
                }
                if (request.Price != null)
                {
                    seats = seats.Where(x => x.Price == request.Price);
                }
                var result = await seats.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<SeatDto>>.Succeed(new PaginationResponse<SeatDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<SeatDto>>.Fail(_localizationService["List of seat are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of seat"
                    }
                });
            }
        }

        public async Task<RequestResult<SeatDto>> GetSeatByCodeAsync(string code, CancellationToken cancellationToken)
        {
            try
            {
                var seat = await _appReadOnlyDbContext.SeatEntities.AsNoTracking().Where(x => x.Code.ToLower() == code.ToLower()).ProjectTo<SeatDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<SeatDto>.Succeed(seat);

            }
            catch (Exception e)
            {

                return RequestResult<SeatDto>.Fail(_localizationService["Seat is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "seat"
                    }
                });
            }
        }

        public async Task<RequestResult<List<SeatDto>>> GetListSeatByIdAsync(List<Guid> listIdSeat, CancellationToken cancellationToken)
        {
            try
            {
                List<SeatDto> listSeat = new();
                foreach (var item in listIdSeat)
                {
                    var seat = await _appReadOnlyDbContext.SeatEntities.AsNoTracking().Where(c => c.Id == item && !c.Deleted).ProjectTo<SeatDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync(cancellationToken);
                    listSeat.Add(seat);
                }
                return RequestResult<List<SeatDto>>.Succeed(listSeat);
            }
            catch (Exception e)
            {
                return RequestResult<List<SeatDto>>.Fail(_localizationService["List seat is not found"], new[]
               {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "List seat"
                    }
                });
            }
        }
    }
}
