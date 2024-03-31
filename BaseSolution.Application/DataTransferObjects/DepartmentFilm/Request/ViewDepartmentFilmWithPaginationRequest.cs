using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request
{
    public class ViewDepartmentFilmWithPaginationRequest : PaginationRequest
    {
        public string? DepartmentName { get; set; }
        public string? FilmTitle { get; set; }
    }
}
