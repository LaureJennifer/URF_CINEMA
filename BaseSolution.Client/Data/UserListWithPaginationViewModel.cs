using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class UserListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<UserDto>? Data { get; set; }
    }
}
