using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom
{
    public class FilmScheduleRoomFindByDateTimeRequest
    {
        public DateTimeOffset? ShowDate { get; set; }
        public DateTimeOffset? ShowTime { get; set; }
    }
}
