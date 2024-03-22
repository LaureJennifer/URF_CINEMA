using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
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

namespace BaseSolution.Infrastructure.ViewModels.FilmSchedule
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
