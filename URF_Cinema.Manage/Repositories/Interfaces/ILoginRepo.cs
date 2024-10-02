using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.ValueObjects.Common;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        //Task<string> Login(LoginInputRequest request);
        Task Logout();
        Task<string> LoginCustomer(LoginInputRequest request);
        Task<RefreshToken> SignIn(LoginInputRequest request);
    }
}
