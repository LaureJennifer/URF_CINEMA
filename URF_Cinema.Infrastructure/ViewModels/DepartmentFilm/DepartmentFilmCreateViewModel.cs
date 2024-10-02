using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.DepartmentFilm
{
    public class DepartmentFilmCreateViewModel : ViewModelBase<DepartmentFilmCreateRequest>
    {
        private readonly IDepartmentFilmReadOnlyRepository _departmentFilmReadOnlyRepository;
        private readonly IDepartmentFilmReadWriteRepository _departmentFilmReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentFilmCreateViewModel(IDepartmentFilmReadOnlyRepository departmentFilmReadOnlyRepository, IDepartmentFilmReadWriteRepository departmentFilmReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentFilmReadOnlyRepository = departmentFilmReadOnlyRepository;
            _departmentFilmReadWriteRepository = departmentFilmReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(DepartmentFilmCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _departmentFilmReadWriteRepository.AddDepartmentFilmAsync(_mapper.Map<DepartmentFilmEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _departmentFilmReadOnlyRepository.GetDepartmentFilmByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
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
                        Error = _localizationService["Error occurred while getting the department film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "department film")
                    }
                };
            }
        }
    }
}
