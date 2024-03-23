using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseSolution.Application.ViewModels.Excels
{
    public class ExcelSeatVM
    {
        public string Code { get; set; }
        public string SeatPosition { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public SeatEntity ConvertToEntity()
        {
            return new SeatEntity()
            {
                Code = Code,
                SeatPosition = SeatPosition,
                Type = Type,
                Price = Price
            };
        }
    }
}
