using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmScheduleRoom
{
    public class FilmScheduleRoomListWithPaginationViewModel :ViewModelBase<ViewFilmScheduleRoomWithPaginationRequest>
    {
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleRoomListWithPaginationViewModel(IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewFilmScheduleRoomWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleRoomReadOnlyRepository.GetFilmScheduleRoomWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of film schedule room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film schedule room")
                    }
                };
            }
        }
    }
}
