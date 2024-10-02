using URF_Cinema.Application.DataTransferObjects.Seat;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class SeatListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<SeatDto>? Data { get; set; }
    }
}
