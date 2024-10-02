using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.FilmSchedule
{
    public class FilmScheduleUpdateViewModel:ViewModelBase<FilmScheduleUpdateRequest>
    {
        private readonly IFilmScheduleReadWriteRepository _filmScheduleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleUpdateViewModel(IFilmScheduleReadWriteRepository filmScheduleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleReadWriteRepository = filmScheduleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleReadWriteRepository.UpdateFilmScheduleAsync(_mapper.Map<FilmScheduleEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the film schedule"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "film schedule")
                    }
                };
            }
        }
    }
}
