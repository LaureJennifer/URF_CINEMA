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
        public Guid Id { get; set; }
        public string Title {  get; set; }
        public DateTimeOffset ShowDate { get; set; }
        public DateTimeOffset ShowTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
