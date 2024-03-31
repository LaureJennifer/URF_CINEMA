using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmScheduleRoom
{
    public class FilmScheduleRoomDto
    {
        public Guid Id { get; set; }

        public Guid FilmScheduleId { get; set; }
        public Guid RoomId { get; set; }
        public string RoomCode { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }

        public EntityStatus Status { get; set; }
    }
}
