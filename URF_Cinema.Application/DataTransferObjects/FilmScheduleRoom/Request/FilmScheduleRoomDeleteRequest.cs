namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class FilmScheduleRoomDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
