using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class FilmListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmDto>? Data { get; set; }
    }
}
