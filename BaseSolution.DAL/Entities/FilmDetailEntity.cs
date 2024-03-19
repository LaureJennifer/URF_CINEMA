using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmDetailEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public FilmEntity FilmEntity { get; set; }
        public FilmScheduleEntity FilmScheduleEntity { get; set; }
    }
}
