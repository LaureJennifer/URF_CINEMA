using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IUserRepo
    {
        public Task<bool> AddAsync(UserCreateRequest request);
        public Task<RequestResult<UserDeleteRequest>> RemoveAsync(UserDeleteRequest request);
        public Task<bool> UpdateAsync(UserUpdateRequest request);
        public Task<RequestResult<UserDto>> GetByIdAsync(Guid id);
        public Task<UserListWithPaginationViewModel> GetAllActive(ViewUserWithPaginationRequest request);
    }
}
