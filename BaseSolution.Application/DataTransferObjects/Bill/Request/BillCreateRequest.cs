using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Bill.Request
{
    public class BillCreateRequest
    {
        public Guid CustomerId { get; set; }
        public int TicketQuantity { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public EntityStatus Status { get; set; }
       
    }
}
