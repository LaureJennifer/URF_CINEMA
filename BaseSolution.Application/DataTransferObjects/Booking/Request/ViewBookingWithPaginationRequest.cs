using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Booking.Request
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
