using URF_Cinema.Application.DataTransferObjects.Room.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Room
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
