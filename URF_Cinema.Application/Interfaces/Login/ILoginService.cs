using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Login
{
    public interface ILoginService
    {
        Task<RequestResult<ViewLoginInput>> Login(LoginInputRequest request,CancellationToken cancellation);
        Task<RequestResult<ViewLoginInput>> LoginCustomer(LoginInputRequest request);
        Task<RequestResult<ViewLoginInput>> SignIn(LoginInputRequest request);
    }
}
