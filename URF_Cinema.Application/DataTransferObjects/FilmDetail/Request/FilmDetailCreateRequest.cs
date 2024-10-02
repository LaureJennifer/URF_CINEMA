namespace URF_Cinema.Application.DataTransferObjects.FilmDetail.Request
{
    public class FilmDetailCreateRequest
    {
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
    }
}
