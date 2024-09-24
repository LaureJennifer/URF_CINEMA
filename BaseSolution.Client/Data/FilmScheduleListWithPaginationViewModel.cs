using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class FilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleDto>? Data { get; set; }
    }
}
