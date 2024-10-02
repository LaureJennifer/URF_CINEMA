using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Department
{
    public class DepartmentDeleteViewModel : ViewModelBase<DepartmentDeleteRequest>
    {
        private readonly IDepartmentReadWriteRepository _departmentReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentDeleteViewModel(IDepartmentReadWriteRepository DepartmentReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentReadWriteRepository = DepartmentReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(DepartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _departmentReadWriteRepository.DeleteDepartmentAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the department"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "department")
                    }
                };
            }
        }
    }
}
