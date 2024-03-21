using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Film
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
