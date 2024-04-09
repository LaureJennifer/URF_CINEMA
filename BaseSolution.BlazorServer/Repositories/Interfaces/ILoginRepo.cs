using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        Task<ViewLoginInput> Login(LoginInputRequest request);
        Task Logout();
    }
}
