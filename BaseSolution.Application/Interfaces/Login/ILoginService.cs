using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Login
{
    public interface ILoginService
    {
        Task<string> Login(string request,CancellationToken cancellation);
        Task<RequestResult<ViewLoginInput>> LoginCustomer(LoginInputRequest request);
        Task<RequestResult<ViewLoginInput>> SignIn(LoginInputRequest request);
    }
}
