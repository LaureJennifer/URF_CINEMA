using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class SeatEntity
    {
        public Guid Id { get; set; }
        public string Code {  get; set; }
        public string SeatPosition { get; set; }
        public double Price { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        public List<RoomSeatEntity> roomSeatEntities { get; set; }
    }
}
