using AutoMapper;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
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
    public class FilmScheduleRoomDeleteRoomViewModel:ViewModelBase<FilmScheduleRoomDeleteRequest>
    {
        private readonly IFilmScheduleRoomReadWriteRepository _filmScheduleRoomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleRoomDeleteRoomViewModel(IFilmScheduleRoomReadWriteRepository filmScheduleRoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleRoomReadWriteRepository = filmScheduleRoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleRoomDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleRoomReadWriteRepository.DeleteFilmScheduleRoomAsync(request, cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the film schedule room"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "film schedule room")
                    }
                };
            }
        }
    }
}
