using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmScheduleEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public List<FilmDetailEntity> FilmDetails { get; set; }
        public List<FilmScheduleRoomEntity> FilmScheduleRooms { get; set; }
    }
}
