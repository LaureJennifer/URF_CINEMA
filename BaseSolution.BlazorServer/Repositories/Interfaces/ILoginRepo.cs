using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        Task<string> Login(LoginInputRequest request);
        Task Logout();
        Task<bool> LoginCustomer(LoginInputRequest request);
    }
}
