using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Bill
{
    public class BillDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DepartmentName { get; set; }
        public double TotalPrice1 { get; set; }
        public int TicketQuantity { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
