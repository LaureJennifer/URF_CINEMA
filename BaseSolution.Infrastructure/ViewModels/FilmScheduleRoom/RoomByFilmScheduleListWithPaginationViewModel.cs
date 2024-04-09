using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
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
    public class RoomByFilmScheduleListWithPaginationViewModel : ViewModelBase<ViewRoomByFilmScheduleWithPaginationRequest>
    {
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public RoomByFilmScheduleListWithPaginationViewModel(IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewRoomByFilmScheduleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleRoomReadOnlyRepository.GetRoomByFilmScheduleWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of film schedule room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film schedule room")
                    }
                };
            }
        }
    }
}
