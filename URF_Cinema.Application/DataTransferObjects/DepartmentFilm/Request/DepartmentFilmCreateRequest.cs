using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request
{
    public class DepartmentFilmCreateRequest
    {
        public Guid DepartmentId { get; set; }
        public Guid FilmId { get; set; }
        public EntityStatus Status { get; set; }
    }
}
