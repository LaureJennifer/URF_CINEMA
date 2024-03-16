using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Role.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
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
        // GET api/<ExampleController>/5
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] ViewRoleWithPaginationRequest request, CancellationToken cancellationToken)
        //{
        //    RoleListWithPaginationViewModel vm = new(_roleReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(request, cancellationToken);

        //    return Ok(vm);
        //}

        //// GET api/<ExampleController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        //{
        //    RoleViewModel vm = new(_roleReadOnlyRepository, _localizationService);

        //    await vm.HandleAsync(id, cancellationToken);

        //    return Ok(vm);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(RoleCreateRequest request, CancellationToken cancellationToken)
        {
            RoleCreateViewModel vm = new(_roleReadOnlyRepository, _roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RoleUpdateRequest request, CancellationToken cancellationToken)
        {
            RoleUpdateViewModel vm = new(_roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RoleDeleteRequest request, CancellationToken cancellationToken)
        {
            RoleDeleteViewModel vm = new(_roleReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
