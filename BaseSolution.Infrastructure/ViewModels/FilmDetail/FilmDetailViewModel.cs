using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.FilmDetail
{
    public class FilmDetailViewModel : ViewModelBase<Guid>
    {
        private readonly IFilmDetailReadOnlyRepository _filmDetailReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmDetailViewModel(IFilmDetailReadOnlyRepository filmDetailReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmDetailReadOnlyRepository = filmDetailReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idFilmDetail, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmDetailReadOnlyRepository.GetFilmDetailByIdAsync(idFilmDetail, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the film detail"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film detail")
                    }
                };
            }
        }
    }
}
