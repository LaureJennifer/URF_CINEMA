using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class FilmDetailListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmDetailDto>? Data { get; set; }
    }
}
