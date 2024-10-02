using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Client.Data
{
    public class FilmScheduleListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<FilmScheduleDto>? Data { get; set; }
    }
}
