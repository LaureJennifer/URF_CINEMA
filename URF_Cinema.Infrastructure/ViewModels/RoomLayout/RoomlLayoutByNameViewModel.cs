using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.RoomLayout
{
    public class RoomlLayoutByNameViewModel :ViewModelBase<string>
    {
        private readonly IRoomLayoutReadOnlyRepository _roomLayoutReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public RoomlLayoutByNameViewModel(IRoomLayoutReadOnlyRepository roomLayoutReadOnlyRepository, ILocalizationService localizationService)
        {
            _roomLayoutReadOnlyRepository = roomLayoutReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(string code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roomLayoutReadOnlyRepository.GetSeatByNameAsync(code, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the room layout"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "room layout")
                    }
                };
            }
        }
    }
}
