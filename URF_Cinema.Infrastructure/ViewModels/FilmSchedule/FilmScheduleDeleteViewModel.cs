using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmSchedule
{
    public class FilmScheduleDeleteViewModel:ViewModelBase<FilmScheduleDeleteRequest>
    {
        private readonly IFilmScheduleReadWriteRepository _filmScheduleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmScheduleDeleteViewModel(IFilmScheduleReadWriteRepository filmScheduleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmScheduleReadWriteRepository = filmScheduleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmScheduleDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmScheduleReadWriteRepository.DeleteFilmScheduleAsync(request, cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "film schedule")
                    }
                };
            }
        }
    }
}
