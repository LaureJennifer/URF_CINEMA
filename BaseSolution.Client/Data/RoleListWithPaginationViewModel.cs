using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class RoleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<RoleDto>? Data { get; set; }
    }
}
