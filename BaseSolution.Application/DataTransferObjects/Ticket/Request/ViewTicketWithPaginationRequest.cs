using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Ticket.Request
{
    public class ViewTicketWithPaginationRequest:PaginationRequest
    {
        public Guid? BillId { get; set; }
        public string? FilmName { get; set; }
        public string? Code { get; set; }
        
    }
}
