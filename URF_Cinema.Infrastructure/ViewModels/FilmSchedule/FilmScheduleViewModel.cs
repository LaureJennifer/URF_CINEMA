using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmSchedule
{
    public class FilmScheduleViewModel : ViewModelBase<Guid>
    {
        private readonly IFilmScheduleReadOnlyRepository _filmScheduleReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleViewModel(IFilmScheduleReadOnlyRepository filmScheduleReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleReadOnlyRepository = filmScheduleReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idFilmSchedule, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleReadOnlyRepository.GetFilmScheduleByIdAsync(idFilmSchedule, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the film schedule"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film schedule")
                    }
                };
            }
        }
    }
}
