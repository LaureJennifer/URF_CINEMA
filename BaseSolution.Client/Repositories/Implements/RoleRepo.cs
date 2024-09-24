using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;
using BaseSolution.Client.Repositories.Interfaces;

namespace BaseSolution.Client.Repositories.Implements
{
    public class RoleRepo : IRoleRepo
    {
        public async Task<RoleListWithPaginationViewModel> GetAllActive()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };

            var obj = await client.GetFromJsonAsync<RoleListWithPaginationViewModel>($"api/Roles");


            if (obj != null)
                return obj;
            return new();
        }

        public async Task<RequestResult<RoleDto>> GetByIdAsync(Guid id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var obj = await client.GetFromJsonAsync<RequestResult<RoleDto>>($"api/Roles/{id}");
            if (obj != null)
                return obj;
            return null;
        }
    }

}
