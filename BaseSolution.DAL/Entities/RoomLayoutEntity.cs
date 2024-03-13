using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoomLayoutEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public DateTimeOffset CreatedTime { get ; set; }
        public Guid? CreatedBy { get; set ; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public List<SeatEntity> Seats { get; set; }
        public List<RoomEntity> Rooms { get; set; }
    }
}
