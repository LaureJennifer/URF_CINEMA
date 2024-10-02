using URF_Cinema.Application.DataTransferObjects.Booking;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Data
{
    public class BookingListWithPaginationViewModel : APIResponse
    {
        public PaginationResponse<BookingDto>? Data { get; set; }
    }
}
