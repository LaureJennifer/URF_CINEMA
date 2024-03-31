using BaseSolution.BlazorServer.Data;
namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        public Task<RoleListWithPaginationViewModel> GetAllActive();
    }
}
