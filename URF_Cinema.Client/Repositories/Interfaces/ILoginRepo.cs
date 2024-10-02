using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Application.DataTransferObjects.Account.Request;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        //Task<string> Login(LoginInputRequest request);
        Task Logout();
        Task<string> LoginCustomer(LoginInputRequest request);
        Task<ViewLoginInput> SignIn(LoginInputRequest request);
    }
}
