using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmDetail.Request
{
    public class FilmDetailCreateRequest
    {
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
    }
}
