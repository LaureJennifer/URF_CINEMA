using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Bill.Request
{
    public class ViewBillWithPaginationRequest : PaginationRequest
    {
        public string? Code { get; set; }
        public string? CustomerName { get; set; }
        public string? DepartmentName { get; set; }

    }
}
