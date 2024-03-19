using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmScheduleRoomEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public RoomEntity RoomEntity { get; set; }
        public FilmScheduleEntity FilmScheduleEntity { get; set; }
    }
}
