namespace URF_Cinema.Application.DataTransferObjects.RoomLayout.Request
{
    public class RoomLayoutDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
