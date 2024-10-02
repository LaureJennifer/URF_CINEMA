using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        public Task<RoleListWithPaginationViewModel> GetAllActive();
        public Task<RequestResult<RoleDto>> GetByIdAsync(Guid id);
    }
}
