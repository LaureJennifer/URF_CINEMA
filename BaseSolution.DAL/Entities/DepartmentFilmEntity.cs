using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class DepartmentFilmEntity
    {
        public Guid DepartmentId { get; set; }
        public Guid FilmId { get; set; }
        public DepartmentEntity DepartmentEntity { get; set; }
        public FilmEntity FilmEntity { get; set; }
    }
}
