using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Department
{
    public class DepartmentViewModel :ViewModelBase<Guid>
    {
        private readonly IDepartmentReadOnlyRepository _departmentReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public DepartmentViewModel(IDepartmentReadOnlyRepository departmentReadOnlyRepository, ILocalizationService localizationService)
        {
            _departmentReadOnlyRepository = departmentReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(Guid idDepartment, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _departmentReadOnlyRepository.GetDepartmentByIdAsync(idDepartment, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the department"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "department")
                    }
                };
            }
        }
    }
}
