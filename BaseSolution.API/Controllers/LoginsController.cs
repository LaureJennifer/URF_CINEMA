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

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginInputRequest> _validator;
        private readonly IOptionsMonitor<Appsetting> _appsetting;

        public LoginsController(ILoginService loginService, ILocalizationService localizationService, IMapper mapper, IValidator<LoginInputRequest> validator,IOptionsMonitor<Appsetting> monitor)
        {
            _loginService = loginService;
            _localizationService = localizationService;
            _mapper = mapper;
            _validator = validator;
            _appsetting = monitor;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginInputRequest request, CancellationToken cancellationToken)
        {
            LoginViewModel vm = new(_loginService, _localizationService,_appsetting);
                await vm.HandleAsync(request, cancellationToken);
            return Ok(vm);
        }
        [HttpPost("Customer")]
        public async Task<IActionResult> LoginCustomer([FromBody] LoginInputRequest request, CancellationToken cancellationToken)
        {
            LoginCustomerViewModel vm = new(_loginService, _localizationService, _appsetting);
            await vm.HandleAsync(request, cancellationToken);
            return Ok(vm);
        }
    }
}
