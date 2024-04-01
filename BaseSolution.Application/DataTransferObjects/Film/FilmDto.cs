using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Film
{
    public class FilmDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string PosterURL { get; set; }
        public string DirectedBy { get; set; }
        public string Language { get; set; }
        public string Actor { get; set; }
        public string TrailerURL { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public List<DateTimeOffset> ShowDates { get; set; }
        public List<DateTimeOffset> ShowTimes { get; set; }
        public List<string> DepartmentNames { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public string Duration { get; set; }
        public string Script { get; set; }
        public string Genres { get; set; }
        public string AgeRating { get; set; }
    }
}
