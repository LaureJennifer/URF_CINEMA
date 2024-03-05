using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmScheduleEntity
    {
        public Guid Id { get; set; }
        //public Guid FilmId { get; set; }
        public DateTime ShowDate { get; set; }
        public DateTime ShowTime { get; set; }
        public List<FilmEntity> Film { get; set; }
    }
}
