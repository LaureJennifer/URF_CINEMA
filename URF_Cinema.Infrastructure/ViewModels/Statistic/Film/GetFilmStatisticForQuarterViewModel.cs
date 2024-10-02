using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Statistic.Film
{
    public class GetFilmStatisticForQuarterViewModel : ViewModelBase<FilmStatisticRequest>
    {
        private readonly IFilmStatisticReadOnlyRespository _filmStatisticReadOnlyRespository;
        private readonly ILocalizationService _localizationService;

        public GetFilmStatisticForQuarterViewModel(IFilmStatisticReadOnlyRespository filmStatisticReadOnlyRespository, ILocalizationService localizationService)
        {
            _filmStatisticReadOnlyRespository = filmStatisticReadOnlyRespository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(FilmStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmStatisticReadOnlyRespository.GetFilmStatisticForQuarterAsync(request, cancellationToken);

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
                            Error = _localizationService["Error occurred while getting the list of film statistic for quarter"],
                            FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film statistic for quarter")
                        }
                };
            }
        }
    }
}
