using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Film
{
    public class FilmStatisticForYearDto
    {       
        public int Year { get; set; }
        public int Views { get; set; } = 1;
        public string DepartmentName { get; set; }
        public string FilmName { get; set; }
    }
}
