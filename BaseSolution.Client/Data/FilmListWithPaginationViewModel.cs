using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class FilmListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmDto>? Data { get; set; }
    }
}
