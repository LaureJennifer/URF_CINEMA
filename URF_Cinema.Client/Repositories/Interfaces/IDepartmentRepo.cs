using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Department;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
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
