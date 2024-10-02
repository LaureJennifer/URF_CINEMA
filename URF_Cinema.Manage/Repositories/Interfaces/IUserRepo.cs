using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
