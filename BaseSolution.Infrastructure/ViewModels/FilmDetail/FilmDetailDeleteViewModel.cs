using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.FilmDetail
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
