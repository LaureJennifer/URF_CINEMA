using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.FilmScheduleRoom
{
    public class FilmScheduleRoomUpdateRoomViewModel :ViewModelBase<FilmScheduleRoomUpdateRequest>
    {
        private readonly IFilmScheduleRoomReadWriteRepository _filmScheduleRoomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleRoomUpdateRoomViewModel(IFilmScheduleRoomReadWriteRepository filmScheduleRoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleRoomReadWriteRepository = filmScheduleRoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleRoomUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleRoomReadWriteRepository.UpdateFilmScheduleRoomAsync(_mapper.Map<FilmScheduleRoomEntity>(request), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "film schedule room")
                    }
                };
            }
        }
    }
}
