using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.FilmSchedule
{
    public class FilmScheduleDto
    {
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public List<FilmDto> Films { get; set; }
        public Guid DepartmentId { get; set; }

        public EntityStatus Status { get; set; }
    }
}
