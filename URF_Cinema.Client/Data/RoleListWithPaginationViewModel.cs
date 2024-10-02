using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class RoleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoleDto>? Data { get; set; }
    }
}
