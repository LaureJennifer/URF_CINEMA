using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        //Task<string> Login(LoginInputRequest request);
        Task Logout();
        Task<string> LoginCustomer(LoginInputRequest request);
        Task<ViewLoginInput> SignIn(LoginInputRequest request);
    }
}
