using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Film
{
    public class FilmUpdateViewModel : ViewModelBase<FilmUpdateRequest>
    {
        private readonly IFilmReadWriteRepository _filmReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmUpdateViewModel(IFilmReadWriteRepository filmReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmReadWriteRepository = filmReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(FilmUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmReadWriteRepository.UpdateFilmAsync(_mapper.Map<FilmEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "film")
                    }
                };
            }
        }
    }
}
