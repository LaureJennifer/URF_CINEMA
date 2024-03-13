using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class BookingEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public Guid RoomId { get; set; }
        public EntityStatus SeatStatus { get; set; } = EntityStatus.Active;
        public RoomEntity RoomEntity { get; set; }
        public SeatEntity SeatEntity { get; set; }
    }
}
