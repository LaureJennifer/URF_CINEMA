namespace URF_Cinema.Application.DataTransferObjects.Film.Request
{
    public class FilmDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
