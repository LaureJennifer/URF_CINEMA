using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleReadOnlyRepository _roleReadOnlyRepository;
        private readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RolesController(IRoleReadOnlyRepository roleReadOnlyRepository, IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadOnlyRepository = roleReadOnlyRepository;
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListRoleByAdmin([FromQuery] ViewRoleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            RoleListWithPaginationViewModel vm = new(_roleReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(Guid id, CancellationToken cancellationToken)
        {
            RoleViewModel vm = new(_roleReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateRequest request, CancellationToken cancellationToken)
        {
            RoleCreateViewModel vm = new(_roleReadOnlyRepository, _roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleUpdateRequest request, CancellationToken cancellationToken)
        {
            RoleUpdateViewModel vm = new(_roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(RoleDeleteRequest request, CancellationToken cancellationToken)
        {
            RoleDeleteViewModel vm = new(_roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
