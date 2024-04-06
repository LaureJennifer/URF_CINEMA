using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.DataTransferObjects.User;
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
    }
}
