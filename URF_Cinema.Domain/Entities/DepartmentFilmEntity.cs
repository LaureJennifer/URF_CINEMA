using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class DepartmentFilmEntity
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid FilmId { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public DepartmentEntity Department { get; set; }
        public FilmEntity Film { get; set; }
    }
}
