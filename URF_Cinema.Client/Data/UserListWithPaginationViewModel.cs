using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Client.Data.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class UserListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<UserDto>? Data { get; set; }
    }
}
