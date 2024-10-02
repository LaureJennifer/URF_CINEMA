using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.RoomLayout
{
    public class RoomLayoutListWithPaginationViewModel:ViewModelBase<ViewRoomLayoutWithPaginationRequest>
    {
        private readonly IRoomLayoutReadOnlyRepository _roomLayoutReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public RoomLayoutListWithPaginationViewModel(IRoomLayoutReadOnlyRepository roomLayoutReadOnlyRepository, ILocalizationService localizationService)
        {
            _roomLayoutReadOnlyRepository = roomLayoutReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewRoomLayoutWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomLayoutReadOnlyRepository.GetRoomLayoutWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of room layout"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of room layout")
                    }
                };
            }
        }
    }
}
