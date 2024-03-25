using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
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

namespace BaseSolution.Infrastructure.ViewModels.DepartmentFilm
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
