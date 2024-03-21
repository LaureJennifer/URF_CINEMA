using BaseSolution.Application.ValueObjects.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.User.Request
{
    public class ViewUserWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }

        public Guid? RoleId { get; set; }
    }
}
