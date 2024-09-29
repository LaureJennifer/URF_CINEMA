using BaseSolution.Application.DataTransferObjects;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using BaseSolution.Infrastructure.Extensions;

namespace BaseSolution.Infrastructure.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase<LoginInputRequest>
    {
        private readonly ILoginService _loginService;
        private readonly ILocalizationService _localizationService;
        public LoginViewModel(ILoginService loginService, ILocalizationService localizationService)
        {
            _loginService = loginService;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(LoginInputRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _loginService.Login(request,cancellationToken);
                Data = /*GenToken.GenerateToken(*/result.Data!;//);
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
                        Error = _localizationService["Login Fail"],
                    }
                };
            }
        }
    }
}
