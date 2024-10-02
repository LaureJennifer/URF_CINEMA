using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.DepartmentFilm
{
    public class DepartmentFilmDto
    {        
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid FilmId { get; set; }
        public string FilmTitle { get; set; }
        public EntityStatus Status { get; set; }
    }
}
