namespace URF_Cinema.Application.DataTransferObjects.FilmDetail.Request
{
    public class FilmDetailDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
