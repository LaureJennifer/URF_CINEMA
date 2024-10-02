using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.DepartmentFilm
{
    public class DepartmentFilmUpdateViewModel : ViewModelBase<DepartmentFilmUpdateRequest>
    {
        private readonly IDepartmentFilmReadWriteRepository _departmentFilmReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentFilmUpdateViewModel(IDepartmentFilmReadWriteRepository departmentFilmReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentFilmReadWriteRepository = departmentFilmReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(DepartmentFilmUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _departmentFilmReadWriteRepository.UpdateDepartmentFilmAsync(_mapper.Map<DepartmentFilmEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the department film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "department film")
                    }
                };
            }
        }
    }
}
