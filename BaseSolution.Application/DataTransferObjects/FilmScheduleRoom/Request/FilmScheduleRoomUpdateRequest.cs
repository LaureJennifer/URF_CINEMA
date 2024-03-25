using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class FilmScheduleRoomUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public Guid? RoomId { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
