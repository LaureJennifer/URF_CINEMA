using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.Department;
using BaseSolution.Infrastructure.ViewModels.DepartmentFilm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentFilmsController : ControllerBase
    {
        private readonly IDepartmentFilmReadOnlyRepository _departmentFilmReadOnlyRepository;
        private readonly IDepartmentFilmReadWriteRepository _departmentFilmReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public DepartmentFilmsController(IDepartmentFilmReadOnlyRepository departmentFilmReadOnlyRepository, IDepartmentFilmReadWriteRepository departmentFilmReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _departmentFilmReadOnlyRepository = departmentFilmReadOnlyRepository;
            _departmentFilmReadWriteRepository = departmentFilmReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListDepartmentFilmByAdmin([FromQuery] ViewDepartmentFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            DepartmentFilmListWithPaginationViewModel vm = new(_departmentFilmReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentFilmById(Guid id, CancellationToken cancellationToken)
        {
            DepartmentFilmViewModel vm = new(_departmentFilmReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartmentFilm(DepartmentFilmCreateRequest request, CancellationToken cancellationToken)
        {
            DepartmentFilmCreateViewModel vm = new(_departmentFilmReadOnlyRepository, _departmentFilmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartmentFilm(DepartmentFilmUpdateRequest request, CancellationToken cancellationToken)
        {
            DepartmentFilmUpdateViewModel vm = new(_departmentFilmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartmentFilm(DepartmentFilmDeleteRequest request, CancellationToken cancellationToken)
        {
            DepartmentFilmDeleteViewModel vm = new(_departmentFilmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
