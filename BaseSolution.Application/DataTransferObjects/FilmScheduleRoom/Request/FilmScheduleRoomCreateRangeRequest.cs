using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class FilmScheduleRoomCreateRangeRequest
    {
        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }

    }
}
