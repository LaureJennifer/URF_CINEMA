using AutoMapper;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadOnlyRepository _UserReadOnlyRepository;
        private readonly IUserReadWriteRepository _UserReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public UsersController(IUserReadOnlyRepository IUserReadOnlyRepository, IUserReadWriteRepository IUserReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _UserReadOnlyRepository = IUserReadOnlyRepository;
            _UserReadWriteRepository = IUserReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        // GET api/<ExampleController>/5
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserViewWithPaginationRequest request, CancellationToken cancellationToken)
        {
            UserListWithPaginationViewModel vm = new(_UserReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        // GET api/<ExampleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            UserViewModel vm = new(_UserReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserCreateRequest request, CancellationToken cancellationToken)
        {
            UserCreateViewModel vm = new(_UserReadOnlyRepository, _UserReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            UserUpdateViewModel vm = new(_UserReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            UserDeleteViewModel vm = new(_UserReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
