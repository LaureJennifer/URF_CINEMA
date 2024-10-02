using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.FilmDetail
{
    public class FilmDetailCreateViewModel:ViewModelBase<FilmDetailCreateRequest>
    {
        private readonly IFilmDetailReadOnlyRepository _filmDetailReadOnlyRepository;
        private readonly IFilmDetailReadWriteRepository _filmDetailReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmDetailCreateViewModel(IFilmDetailReadOnlyRepository filmDetailReadOnlyRepository, IFilmDetailReadWriteRepository filmDetailReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmDetailReadOnlyRepository = filmDetailReadOnlyRepository;
            _filmDetailReadWriteRepository = filmDetailReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(FilmDetailCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _filmDetailReadWriteRepository.AddFilmDetailAsync(_mapper.Map<FilmDetailEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _filmDetailReadOnlyRepository.GetFilmDetailByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the film detail"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "film detail")
                    }
                };
            }
        }
    }
}
