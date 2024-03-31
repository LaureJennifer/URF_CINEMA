using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;

namespace BaseSolution.BlazorServer.Repositories.Implements
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
    }
}
