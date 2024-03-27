using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        public Task<UserCreateRequest> AddAsync(UserCreateRequest request);
        public Task<RequestResult<UserDeleteRequest>> RemoveAsync(UserDeleteRequest request);
        public Task<RequestResult<UserDto>> GetByIdAsync(Guid id);
        public Task<UserListWithPaginationViewModel> GetAllActive(ViewUserWithPaginationRequest request);
    }
}
