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
        public Guid? CustomerId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? Code { get; set; }
        public string? CustomerName { get; set; }
        public string? DepartmentName { get; set; }

    }
}
