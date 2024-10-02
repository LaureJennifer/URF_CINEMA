using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmDetail.Request
{
    public class FilmDetailUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? FilmId { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
