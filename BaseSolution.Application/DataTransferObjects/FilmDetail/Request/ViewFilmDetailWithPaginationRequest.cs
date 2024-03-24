using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmDetail.Request
{
    public class ViewFilmDetailWithPaginationRequest :PaginationRequest
    {
        public string? FilmName { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
