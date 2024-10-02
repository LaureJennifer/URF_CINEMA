using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.FilmSchedule
{
    public class FilmScheduleCreateViewModel : ViewModelBase<FilmScheduleCreateRequest>
    {
        private readonly IFilmScheduleReadOnlyRepository _filmScheduleReadOnlyRepository;
        private readonly IFilmScheduleReadWriteRepository _filmScheduleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleCreateViewModel(IFilmScheduleReadOnlyRepository filmScheduleReadOnlyRepository, IFilmScheduleReadWriteRepository filmScheduleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleReadOnlyRepository = filmScheduleReadOnlyRepository;
            _filmScheduleReadWriteRepository = filmScheduleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _filmScheduleReadWriteRepository.AddFilmScheduleAsync(_mapper.Map<FilmScheduleEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _filmScheduleReadOnlyRepository.GetFilmScheduleByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the film schedule"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film schedule")
                    }
                };
            }
        }
    }
}
