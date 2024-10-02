using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.Interfaces.Login;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using URF_Cinema.Infrastructure.ViewModels.Customer;
using URF_Cinema.Infrastructure.ViewModels;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public LoginsController(ILoginService loginService, ILocalizationService localizationService, IMapper mapper)
        {
            _loginService = loginService;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputRequest request, CancellationToken cancellationToken)
        {
            LoginViewModel vm = new(_loginService, _localizationService);
                await vm.HandleAsync(request, cancellationToken);
            return Ok(vm);
        }
        [HttpPost("Customer")]
        public async Task<IActionResult> LoginCustomer([FromBody] LoginInputRequest request, CancellationToken cancellationToken)
        {
            LoginCustomerViewModel vm = new(_loginService, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            return Ok(vm);
        }
        [HttpPost("SignInPassword")]
        public async Task<IActionResult> SignInPassword([FromBody] LoginInputRequest request, CancellationToken cancellationToken)
        {
            SignInViewModel vm = new(_loginService, _localizationService);
            await vm.HandleAsync(request, cancellationToken);
            return Ok(vm);
        }
    }
}
