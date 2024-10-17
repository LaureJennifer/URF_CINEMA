using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
using URF_Cinema.Client.Data;
using URF_Cinema.Client.Repositories.Interfaces;
using URF_Cinema.Client.Data.ValueObjects.Pagination;
public class DepartmentFilmRepo : IDepartmentFilmRepo
{
    public async Task<DepartmentFilmWithPaginationViewModel> GetAllActive(ViewDepartmentFilmWithPaginationRequest request)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7005")
        };
        var obj = await client.GetFromJsonAsync<DepartmentFilmWithPaginationViewModel>($"api/DepartmentFilms?DepartmentName={request.DepartmentName}&PageSize={request.PageSize}");
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
