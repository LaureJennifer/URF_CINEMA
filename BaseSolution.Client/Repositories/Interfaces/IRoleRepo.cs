using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        public Task<RoleListWithPaginationViewModel> GetAllActive();
        public Task<RequestResult<RoleDto>> GetByIdAsync(Guid id);
    }
}
