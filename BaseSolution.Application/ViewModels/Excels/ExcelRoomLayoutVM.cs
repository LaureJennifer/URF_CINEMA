using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.ViewModels.Excels
{
    public class ExcelRoomLayoutVM
    {
        public string Name {  get; set; }
        public RoomLayoutEntity ConvertToEntity()
        {
            return new RoomLayoutEntity()
            {
                Name = Name,
            };
        }
    }
}
