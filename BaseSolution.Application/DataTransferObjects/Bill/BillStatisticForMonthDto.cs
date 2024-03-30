using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Bill
{
    public class BillStatisticForMonthDto
    {
        public int Month {  get; set; }
        public int Year { get; set; }
        public double Revenue { get; set; }
        

    }
}
