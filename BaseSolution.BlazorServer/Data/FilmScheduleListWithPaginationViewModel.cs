using BaseSolution.BlazorServer.Data.DataTransferObjects.Film;
using BaseSolution.BlazorServer.ValueObjects.Pagination;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class FilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmDto>? Data { get; set; }
    }
}
