using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Room
{
    public class RoomListWithPaginationViewModel:ViewModelBase<ViewRoomWithPaginationRequest>
    {
        private readonly IRoomReadOnlyRepository _roomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public RoomListWithPaginationViewModel(IRoomReadOnlyRepository roomReadOnlyRepository, ILocalizationService localizationService)
        {
            _roomReadOnlyRepository = roomReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomReadOnlyRepository.GetRoomWithPaginationByAdminAsync(request, cancellationToken);

                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {

                Success = false;
                ErrorItems = new[]
                {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the list of room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of room")
                    }
                };
            }
        }
    }
}
