using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmDetailEntity
    {
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
        public FilmEntity FilmEntity { get; set; }
        public FilmScheduleEntity FilmScheduleEntity { get; set; }
    }
}
