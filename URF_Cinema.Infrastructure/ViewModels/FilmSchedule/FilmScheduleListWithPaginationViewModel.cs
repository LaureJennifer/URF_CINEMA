using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmSchedule
{
    public class FilmScheduleListWithPaginationViewModel : ViewModelBase<ViewFilmScheduleWithPaginationRequest>
    {
        private readonly IFilmScheduleReadOnlyRepository _filmScheduleReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleListWithPaginationViewModel(IFilmScheduleReadOnlyRepository filmScheduleReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleReadOnlyRepository = filmScheduleReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleReadOnlyRepository.GetFilmScheduleWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of film schedule"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film schedule")
                    }
                };
            }
        }
    }
}
