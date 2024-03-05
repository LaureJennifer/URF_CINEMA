using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; set; }
        public string Capacity { get; set; }
        public string Code { get; set; }
        public string RoomType { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }
        public List<DepartmentRoomEntity> departmentRoomEntities { get; set; }
        public List<RoomSeatEntity> RoomSeatEntities { get; set; }
    }
}
