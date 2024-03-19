using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmDetail.Request
{
    public class FilmDetailDeleteRequest
    {
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
    }
}
