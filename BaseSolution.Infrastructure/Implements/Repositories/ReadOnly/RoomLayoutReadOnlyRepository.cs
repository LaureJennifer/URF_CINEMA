using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
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
    public class RoomLayoutReadOnlyRepository : IRoomLayoutReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public RoomLayoutReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<RoomLayoutDto?>> GetRoomLayoutByIdAsync(Guid idRoomLayout, CancellationToken cancellationToken)
        {
            try
            {
                var roomLayout = await _appReadOnlyDbContext.RoomLayoutEntities.AsNoTracking().Where(c => c.Id == idRoomLayout && !c.Deleted).ProjectTo<RoomLayoutDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<RoomLayoutDto?>.Succeed(roomLayout);
            }
            catch (Exception e)
            {
                return RequestResult<RoomLayoutDto?>.Fail(_localizationService["Room layout is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Room layout"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<RoomLayoutDto>>> GetRoomLayoutWithPaginationByAdminAsync(ViewRoomLayoutWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var roomLayouts = _appReadOnlyDbContext.RoomLayoutEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<RoomLayoutDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    roomLayouts = roomLayouts.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
                if (request.Status != null)
                {
                    roomLayouts = roomLayouts.Where(x => x.Status == request.Status);
                }
                var result = await roomLayouts.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<RoomLayoutDto>>.Succeed(new PaginationResponse<RoomLayoutDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<RoomLayoutDto>>.Fail(_localizationService["List of room layout are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of room layout"
                    }
                });
            }
        }
    }
}
