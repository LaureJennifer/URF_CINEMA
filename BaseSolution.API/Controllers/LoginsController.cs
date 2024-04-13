using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.Login;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using BaseSolution.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using BaseSolution.Application.DataTransferObjects;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.ViewModels.Customer;
using BaseSolution.Infrastructure.ViewModels;
using System.Threading;

namespace BaseSolution.API.Controllers
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
        public async Task<IActionResult> Login(string request, CancellationToken cancellationToken)
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
