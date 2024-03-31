using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public Task<bool> AddAsync(DepartmentCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentListWithPaginationViewModel> GetAllActive(ViewDepartmentWithPaginationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<DepartmentDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<DepartmentDeleteRequest>> RemoveAsync(DepartmentDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(DepartmentUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
