namespace URF_Cinema.Application.DataTransferObjects.Room.Request
{
    public class RoomDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
