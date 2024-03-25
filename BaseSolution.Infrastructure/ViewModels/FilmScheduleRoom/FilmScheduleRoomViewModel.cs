using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.FilmScheduleRoom
{
    public class FilmScheduleRoomViewModel : ViewModelBase<Guid>
    {
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmScheduleRoomViewModel(IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idFilmScheduleRoom, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleRoomReadOnlyRepository.GetFilmScheduleRoomByIdAsync(idFilmScheduleRoom, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the film schedule room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film schedule room")
                    }
                };
            }
        }
    }
}
