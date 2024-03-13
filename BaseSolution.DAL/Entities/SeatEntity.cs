using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class SeatEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid RoomLayoutId { get; set; }
        public string Code {  get; set; }
        public string SeatPosition { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }  
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public RoomLayoutEntity RoomLayoutEntity { get; set; }
        public List<BookingEntity> Bookings { get; set; }
    }
}
