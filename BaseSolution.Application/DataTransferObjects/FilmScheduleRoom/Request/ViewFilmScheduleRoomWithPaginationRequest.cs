using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class ViewFilmScheduleRoomWithPaginationRequest:PaginationRequest
    {
        public string? RoomCode { get; set; }
        public DateTimeOffset? ShowDate { get; set; }
        public DateTimeOffset? ShowTime { get; set; }
    }
}
