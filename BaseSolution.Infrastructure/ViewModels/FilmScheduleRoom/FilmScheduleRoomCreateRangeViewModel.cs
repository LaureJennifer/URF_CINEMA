using AutoMapper;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.FilmScheduleRoom
{
    public class FilmScheduleRoomCreateRangeViewModel : ViewModelBase<List<FilmScheduleRoomCreateRangeRequest>>
    {
        private readonly IFilmScheduleRoomReadWriteRepository _filmScheduleRoomReadWriteRepository;
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleRoomCreateRangeViewModel(IFilmScheduleRoomReadWriteRepository filmScheduleRoomReadWriteRepository, IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleRoomReadWriteRepository = filmScheduleRoomReadWriteRepository;
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(List<FilmScheduleRoomCreateRangeRequest> data, CancellationToken cancellationToken)
        {
            try
            {
                var resultCreate = await _filmScheduleRoomReadWriteRepository.CreateRangeFilmScheduleRoomAsync(_mapper.Map<List<FilmScheduleRoomEntity>>(data), cancellationToken);
                if (resultCreate.Success)
                {
                    var result = await _filmScheduleRoomReadOnlyRepository.GetListFilmScheduleRoomByIdAsync(resultCreate.Data, cancellationToken);
                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }
                Success = resultCreate.Success;
                ErrorItems = resultCreate.Errors;
                Message = resultCreate.Message;
            }
            catch (Exception)
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
