using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Ticket
{
    public class TicketStatisticForQuarterDto
    {
        public int Quarter { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public string DepartmentName { get; set; }

    }
}
