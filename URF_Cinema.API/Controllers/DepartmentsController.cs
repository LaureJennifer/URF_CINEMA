﻿using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentReadOnlyRepository _departmentReadOnlyRepository;
        private readonly IDepartmentReadWriteRepository _departmentReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentReadOnlyRepository departmentReadOnlyRepository, IDepartmentReadWriteRepository departmentReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentReadOnlyRepository = departmentReadOnlyRepository;
            _departmentReadWriteRepository = departmentReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListDepartmentByAdmin([FromQuery] ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken)
        {
            DepartmentListWithPaginationViewModel vm = new(_departmentReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id, CancellationToken cancellationToken)
        {
            DepartmentViewModel vm = new(_departmentReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentCreateRequest request, CancellationToken cancellationToken)
        {
            DepartmentCreateViewModel vm = new(_departmentReadOnlyRepository, _departmentReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentUpdateRequest request, CancellationToken cancellationToken)
        {
            DepartmentUpdateViewModel vm = new(_departmentReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromQuery]DepartmentDeleteRequest request, CancellationToken cancellationToken)
        {
            DepartmentDeleteViewModel vm = new(_departmentReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
