using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoomSeatEntity
    {
        public Guid RoomId { get; set; }
        public Guid SeatId { get; set; }
        public string Type { get; set; }

        public RoomEntity RoomEntity { get; set; }
        public SeatEntity SeatEntity { get; set; }
    }
}
