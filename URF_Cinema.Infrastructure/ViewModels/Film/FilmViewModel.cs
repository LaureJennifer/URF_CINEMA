using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Film
{
    public class FilmViewModel : ViewModelBase<Guid>
    {
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmViewModel(IFilmReadOnlyRepository filmReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idFilm, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmReadOnlyRepository.GetFilmByIdAsync(idFilm, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film")
                    }
                };
            }
        }
    }
}
