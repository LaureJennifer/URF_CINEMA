using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.Interfaces.Login;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Login
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
