using BaseSolution.Application.ValueObjects.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Role.Request
{
    public class ViewRoleWithPaginationRequest : PaginationRequest
    {
        public string? Code { get; set; }

    }
}
