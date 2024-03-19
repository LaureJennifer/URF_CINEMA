using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class DepartmentFilmEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid FilmId { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public DepartmentEntity DepartmentEntity { get; set; }
        public FilmEntity FilmEntity { get; set; }
    }
}
