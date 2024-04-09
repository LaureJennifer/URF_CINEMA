using BaseSolution.Application.ValueObjects.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class ViewRoomByFilmScheduleWithPaginationRequest:PaginationRequest
    {
        public Guid? FilmScheduleId { get; set; }
    }
}
