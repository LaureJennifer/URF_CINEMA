using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Application.DataTransferObjects.Room.Request;
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
    public class RoomReadOnlyRepository : IRoomReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public RoomReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<RoomDto?>> GetRoomByIdAsync(Guid idRoom, CancellationToken cancellationToken)
        {
            try
            {
                var room = await _appReadOnlyDbContext.RoomEntities.AsNoTracking().Where(x => x.Id == idRoom).ProjectTo<RoomDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<RoomDto?>.Succeed(room);

            }
            catch (Exception e)
            {

                return RequestResult<RoomDto?>.Fail(_localizationService["Room is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Room"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<RoomDto>>> GetRoomWithPaginationByAdminAsync(ViewRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var rooms = _appReadOnlyDbContext.RoomEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<RoomDto>(_mapper.ConfigurationProvider);
                if (request.DepartmentId!=null)
                {
                    rooms = rooms.Where(x => x.DepartmentId==request.DepartmentId);
                }
                if (!string.IsNullOrWhiteSpace(request.RoomLayoutName))
                {
                    rooms = rooms.Where(x => x.RoomLayoutName.ToLower().Contains(request.RoomLayoutName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.DepartmentName))
                {
                    rooms = rooms.Where(x => x.DepartmentName.ToLower().Contains(request.DepartmentName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    rooms = rooms.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));
                }
                var result = await rooms.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<RoomDto>>.Succeed(new PaginationResponse<RoomDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<RoomDto>>.Fail(_localizationService["List of room are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of room"
                    }
                });
            }
        }
    }
}
