using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Film
{
    public class FilmListWithPaginationViewModel: ViewModelBase<ViewFilmWithPaginationRequest>
    {
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmListWithPaginationViewModel(IFilmReadOnlyRepository filmReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(ViewFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmReadOnlyRepository.GetFilmWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film")
                    }
                };
            }
        }
    }
}
