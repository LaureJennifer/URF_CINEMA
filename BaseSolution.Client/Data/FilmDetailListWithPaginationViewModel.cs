using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class FilmDetailListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmDetailDto>? Data { get; set; }
    }
}
