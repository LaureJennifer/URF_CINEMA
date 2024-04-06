using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async override Task HandleAsync(LoginInputRequest data, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _loginService.Login(data);
                Data = result.Data;
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
