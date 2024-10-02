using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Department
{
    public class DepartmentCreateViewModel : ViewModelBase<DepartmentCreateRequest>
    {
        private readonly IDepartmentReadOnlyRepository _departmentReadOnlyRepository;
        private readonly IDepartmentReadWriteRepository _departmentReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentCreateViewModel(IDepartmentReadOnlyRepository DepartmentReadOnlyRepository, IDepartmentReadWriteRepository DepartmentReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentReadOnlyRepository = DepartmentReadOnlyRepository;
            _departmentReadWriteRepository = DepartmentReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(DepartmentCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _departmentReadWriteRepository.AddDepartmentAsync(_mapper.Map<DepartmentEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _departmentReadOnlyRepository.GetDepartmentByIdAsync(createResult.Data, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the department"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "department")
                    }
                };
            }
        }
    }
}
