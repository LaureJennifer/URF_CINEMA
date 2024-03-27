using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class UserListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<UserDto>? Data { get; set; }
    }
}
