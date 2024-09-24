using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.ValueObjects.Common;


namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        //Task<string> Login(LoginInputRequest request);
        Task Logout();
        Task<string> LoginCustomer(LoginInputRequest request);
        Task<RefreshToken> SignIn(LoginInputRequest request);
    }
}
