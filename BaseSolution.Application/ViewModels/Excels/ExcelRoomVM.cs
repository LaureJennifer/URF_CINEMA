using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseSolution.Application.ViewModels.Excels
{
    public class ExcelRoomVM
    {
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }
        public RoomEntity ConvertToEntity()
        {
            return new RoomEntity()
            {
                Code = Code,
                Capacity = Capacity,
                SoundSystem = SoundSystem,
                ScreenSize = ScreenSize
            };
        }
    }
}
