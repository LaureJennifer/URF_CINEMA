using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class DepartmentListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<DepartmentDto>? Data { get; set; }
    }
}
