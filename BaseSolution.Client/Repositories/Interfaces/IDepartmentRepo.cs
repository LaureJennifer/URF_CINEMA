using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IDepartmentRepo
    {
        public Task<bool> AddAsync(DepartmentCreateRequest request);
        public Task<RequestResult<DepartmentDeleteRequest>> RemoveAsync(DepartmentDeleteRequest request);
        public Task<bool> UpdateAsync(DepartmentUpdateRequest request);
        public Task<RequestResult<DepartmentDto>> GetByIdAsync(Guid id);
        public Task<DepartmentListWithPaginationViewModel> GetAllActive(ViewDepartmentWithPaginationRequest request);
       
    }
}
