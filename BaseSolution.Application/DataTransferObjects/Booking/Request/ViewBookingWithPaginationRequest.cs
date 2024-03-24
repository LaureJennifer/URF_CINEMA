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
        public Guid? SeatId { get; set; }
        public Guid? RoomId { get; set; }
    }
}
