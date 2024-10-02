using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IDepartmentReadWriteRepository
    {
        Task<RequestResult<Guid>> AddDepartmentAsync(DepartmentEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateDepartmentAsync(DepartmentEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteDepartmentAsync(DepartmentDeleteRequest request, CancellationToken cancellationToken);
    }
}
