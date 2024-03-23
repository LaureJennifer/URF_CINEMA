using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Room
{
    public class RoomDto
    {
        public string RoomLayoutName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }
        public EntityStatus Status { get; set; }
    }
}
