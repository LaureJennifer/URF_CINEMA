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
    public class FilmScheduleViewModel : ViewModelBase<Guid>
    {
        private readonly IFilmScheduleReadOnlyRepository _filmScheduleReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleViewModel(IFilmScheduleReadOnlyRepository filmScheduleReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleReadOnlyRepository = filmScheduleReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idFilmSChedule, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleReadOnlyRepository.GetFilmScheduleByIdAsync(idFilmSChedule, cancellationToken);
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
