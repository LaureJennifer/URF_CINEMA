using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class UserListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<UserDto>? Data { get; set; }
    }
}
