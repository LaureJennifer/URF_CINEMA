
using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Pagination;


public class DepartmentFilmRepo : IDepartmentFilmRepo
{
    public async Task<DepartmentFilmWithPaginationViewModel> GetAllActive(ViewDepartmentFilmWithPaginationRequest request)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7005")
        };
        var obj = await client.GetFromJsonAsync<DepartmentFilmWithPaginationViewModel>($"api/DepartmentFilms?DepartmentId={request.DepartmentId}&PageSize={request.PageSize}");
        if (obj != null)
            return obj;
        return new();
    }

    public async Task<PaginationResponse<DepartmentFilmDto>> GetAllDepartmentFilmByDepartment(ViewDepartmentFilmWithPaginationRequest request)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7005")
        };
        var obj = await client.GetFromJsonAsync<PaginationResponse<DepartmentFilmDto>>($"api/DepartmentFilms?DepartmentId={request.DepartmentId}&PageSize={request.PageSize}");
        if (obj != null)
            return obj;
        return new();
    } 
}
