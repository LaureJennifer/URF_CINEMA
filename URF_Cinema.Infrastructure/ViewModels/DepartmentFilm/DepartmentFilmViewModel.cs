using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.DepartmentFilm
{
    public class DepartmentFilmViewModel : ViewModelBase<Guid>
    {
        private readonly IDepartmentFilmReadOnlyRepository _departmentFilmReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public DepartmentFilmViewModel(IDepartmentFilmReadOnlyRepository departmentFilmReadOnlyRepository, ILocalizationService localizationService)
        {
            _departmentFilmReadOnlyRepository = departmentFilmReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _departmentFilmReadOnlyRepository.GetDepartmentFilmByIdAsync(idDepartment, cancellationToken);
                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
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
