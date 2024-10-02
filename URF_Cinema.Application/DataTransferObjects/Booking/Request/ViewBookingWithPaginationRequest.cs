using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Booking.Request
{
    public class ViewBookingWithPaginationRequest : PaginationRequest
    {
        public Guid? Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? FilmId { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public EntityStatus? SeatStatus { get; set; }

        public DateTimeOffset? ExpiredTime { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
    }
}
