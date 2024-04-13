using BaseSolution.Application.DataTransferObjects;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BaseSolution.Infrastructure.ViewModels.Customer
{
    public class LoginCustomerViewModel : ViewModelBase<LoginInputRequest>
    {
        private readonly ILoginService _loginService;
        private readonly ILocalizationService _localizationService;
        public LoginCustomerViewModel(ILoginService loginService, ILocalizationService localizationService)
        {
            _loginService = loginService;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(LoginInputRequest data, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _loginService.LoginCustomer(data);
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
