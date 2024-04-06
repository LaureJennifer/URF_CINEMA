using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.VnPayment
{
    public class VnPayRequest
    {
        public string FullName { get; set; }
        public Guid BookingId { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public DateTimeOffset CreatedDate {  get; set; }
    }
}
