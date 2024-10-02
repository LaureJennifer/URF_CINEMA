using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;

namespace URF_Cinema.Client.Repositories.Implements
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
