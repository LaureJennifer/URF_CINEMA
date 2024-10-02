using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmDetail
{
    public class FilmDetailDeleteViewModel:ViewModelBase<FilmDetailDeleteRequest>
    {
        private readonly IFilmDetailReadWriteRepository _filmDetailReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmDetailDeleteViewModel(IFilmDetailReadWriteRepository filmDetailReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmDetailReadWriteRepository = filmDetailReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmDetailDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmDetailReadWriteRepository.DeleteFilmDetailAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the film detail"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "film detail")
                    }
                };
            }
        }
    }
}
