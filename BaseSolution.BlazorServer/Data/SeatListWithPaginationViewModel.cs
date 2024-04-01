using BaseSolution.Application.DataTransferObjects.Seat;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Data
{
    public class SeatListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<SeatDto>? Data { get; set; }
    }
}
