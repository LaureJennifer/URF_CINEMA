using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.Client.Data
{
    public class BookingListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<BookingDto>? Data { get; set; }
    }
}
