using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.ViewModels.Excels
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
