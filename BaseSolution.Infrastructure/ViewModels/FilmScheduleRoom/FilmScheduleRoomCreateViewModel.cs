using AutoMapper;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
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
    public class FilmScheduleRoomCreateViewModel:ViewModelBase<FilmScheduleRoomCreateRequest>
    {
        private readonly IFilmScheduleRoomReadOnlyRepository _filmScheduleRoomReadOnlyRepository;
        private readonly IFilmScheduleRoomReadWriteRepository _filmScheduleRoomReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleRoomCreateViewModel(IFilmScheduleRoomReadOnlyRepository filmScheduleRoomReadOnlyRepository, IFilmScheduleRoomReadWriteRepository filmScheduleRoomReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleRoomReadOnlyRepository = filmScheduleRoomReadOnlyRepository;
            _filmScheduleRoomReadWriteRepository = filmScheduleRoomReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleRoomCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _filmScheduleRoomReadWriteRepository.AddFilmScheduleRoomAsync(_mapper.Map<FilmScheduleRoomEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _filmScheduleRoomReadOnlyRepository.GetFilmScheduleRoomByIdAsync(createResult.Data, cancellationToken);

                    Data = createResult;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }

                Success = createResult.Success;
                ErrorItems = createResult.Errors;
                Message = createResult.Message;
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
