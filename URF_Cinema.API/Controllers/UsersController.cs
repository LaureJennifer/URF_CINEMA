using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserReadWriteRepository _userReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public UsersController(IUserReadOnlyRepository userReadOnlyRepository, IUserReadWriteRepository userReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userReadWriteRepository = userReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetListUserByAdmin([FromQuery] ViewUserWithPaginationRequest request, CancellationToken cancellationToken)
        {
            UserListWithPaginationViewModel vm = new(_userReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            UserViewModel vm = new(_userReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequest request, CancellationToken cancellationToken)
        {
            UserCreateViewModel vm = new(_userReadOnlyRepository, _userReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            UserUpdateViewModel vm = new(_userReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery]UserDeleteRequest request, CancellationToken cancellationToken)
        {
            UserDeleteViewModel vm = new(_userReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
