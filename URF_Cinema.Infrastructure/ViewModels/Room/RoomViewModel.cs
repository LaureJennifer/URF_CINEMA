using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Room
{
    public class RoomViewModel:ViewModelBase<Guid>
    {
        private readonly IRoomReadOnlyRepository _roomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;
       
        public RoomViewModel(IRoomReadOnlyRepository roomReadOnlyRepository, ILocalizationService localizationService)
        {
            _roomReadOnlyRepository = roomReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idRoom, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomReadOnlyRepository.GetRoomByIdAsync(idRoom, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "room")
                    }
                };
            }
        }
    }
}
