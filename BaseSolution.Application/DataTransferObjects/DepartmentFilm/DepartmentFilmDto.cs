using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.DepartmentFilm
{
    public class DepartmentFilmDto
    {        
        public string DepartmentName { get; set; }
        public string FilmTitle { get; set; }
        public EntityStatus Status { get; set; }
    }
}
