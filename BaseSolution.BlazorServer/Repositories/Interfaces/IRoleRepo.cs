using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        public Task<RoleListWithPaginationViewModel> GetAllActive();
        public Task<RequestResult<RoleDto>> GetByIdAsync(Guid id);
    }
}
