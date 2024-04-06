using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Seat.Request
{
    public class ViewSeatWithPaginationRequest:PaginationRequest
    {
        public string? RoomLayoutName { get; set; }
        public string? Code { get; set; }
        public EntityTypeSeat? Type { get; set; }
        public double? Price { get; set; }
    }
}
