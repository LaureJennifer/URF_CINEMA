using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Film
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
