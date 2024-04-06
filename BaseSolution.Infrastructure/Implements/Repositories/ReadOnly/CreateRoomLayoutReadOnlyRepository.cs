using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CreateRoomLayoutReadOnlyRepository : ICreateRoomLayoutReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public CreateRoomLayoutReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<List<RoomLayoutDto>>> GetListRoomLayoutByIdAsync(List<Guid> idRoomLayout, CancellationToken cancellationToken)
        {
            try
            {
                List<RoomLayoutDto> listRoomLayout = new();
                foreach (var item in idRoomLayout)
                {
                    var roomlayout = await _appReadOnlyDbContext.RoomLayoutEntities.AsNoTracking().Where(c => c.Id == item && !c.Deleted).ProjectTo<RoomLayoutDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync(cancellationToken);
                    listRoomLayout.Add(roomlayout);
                }
                return RequestResult<List<RoomLayoutDto>>.Succeed(listRoomLayout);
            }
            catch (Exception e)
            {
                return RequestResult<List<RoomLayoutDto>>.Fail(_localizationService["RoomLayout is not found"], new[]
               {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "roomlayout"
                    }
                });
            }
        }
    }
}
