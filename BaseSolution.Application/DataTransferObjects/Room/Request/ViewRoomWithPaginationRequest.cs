using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Room.Request
{
    public class ViewRoomWithPaginationRequest : PaginationRequest
    {
        public string? RoomLayoutName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Code { get; set; }

    }
}
