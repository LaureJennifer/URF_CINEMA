using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        public Task<RoleListWithPaginationViewModel> GetAllActive();
        public Task<RequestResult<RoleDto>> GetByIdAsync(Guid id);
    }
}
