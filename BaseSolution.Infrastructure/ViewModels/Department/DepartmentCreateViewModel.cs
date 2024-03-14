using AutoMapper;
using Azure.Core;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Department
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
                        Error = _localizationService["Error occurred while getting the Department"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "Department")
                    }
                };
            }
        }
    }
}
