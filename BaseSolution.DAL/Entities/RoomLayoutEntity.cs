using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoomLayoutEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public DateTimeOffset CreatedTime { get ; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public List<SeatEntity> Seats { get; set; }
        public List<RoomEntity> Rooms { get; set; }
    }
}
