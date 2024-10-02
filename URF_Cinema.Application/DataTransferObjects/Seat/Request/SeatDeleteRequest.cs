namespace URF_Cinema.Application.DataTransferObjects.Seat.Request
{
    public class SeatDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
