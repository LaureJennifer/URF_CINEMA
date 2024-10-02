using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.DataTransferObjects.User.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IUserReadOnlyRepository
    {
        Task<RequestResult<UserDto?>> GetUserByIdAsync(Guid idUser, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<UserDto>>> GetUserWithPaginationByAdminAsync(
            ViewUserWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<UserDto>> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    }
}
