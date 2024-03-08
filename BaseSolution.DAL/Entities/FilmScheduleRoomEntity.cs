using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmScheduleRoomEntity
    {
        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }
        public RoomEntity RoomEntity { get; set; }
        public FilmScheduleEntity FilmScheduleEntity { get; set; }
    }
}
