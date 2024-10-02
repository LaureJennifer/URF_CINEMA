using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request
{
    public class DepartmentFilmUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? FilmId { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
