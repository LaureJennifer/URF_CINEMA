using URF_Cinema.Application.DataTransferObjects.Department;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class DepartmentListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<DepartmentDto>? Data { get; set; }
    }
}
