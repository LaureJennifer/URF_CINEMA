using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmSchedule
{
    public class FilmScheduleDto
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
        public DateTime ShowDate { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
