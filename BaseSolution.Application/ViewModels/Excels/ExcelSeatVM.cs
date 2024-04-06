using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
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
        public string Row { get; set; }
        public int SeatColumn { get; set; }
        public EntityTypeSeat Type { get; set; }
        public double Price { get; set; }
        public SeatEntity ConvertToEntity()
        {
            return new SeatEntity()
            {
                Code = Code,
                Row = Row,
                SeatColumn = SeatColumn,
                Type = Type,
                Price = Price
            };
        }
    }
}
