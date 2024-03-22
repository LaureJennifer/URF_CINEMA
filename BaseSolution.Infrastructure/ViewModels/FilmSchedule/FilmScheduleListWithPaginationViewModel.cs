using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BaseSolution.Infrastructure.ViewModels.FilmSchedule
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
