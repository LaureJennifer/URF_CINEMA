using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Department
{
    public class DepartmentUpdateViewModel : ViewModelBase<DepartmentUpdateRequest>
    {
        private readonly IDepartmentReadWriteRepository _departmentReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentUpdateViewModel(IDepartmentReadWriteRepository DepartmentReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentReadWriteRepository = DepartmentReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(DepartmentUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _departmentReadWriteRepository.UpdateDepartmentAsync(_mapper.Map<DepartmentEntity>(request), cancellationToken);

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
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "department")
                    }
                };
            }
        }
    }
}
