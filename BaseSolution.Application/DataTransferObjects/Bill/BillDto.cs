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
        public Guid UserId { get; set; }
        public double Price { get; set; }
        public double TotalPayment { get; set; }
        public string Description { get; set; }
    }
}
