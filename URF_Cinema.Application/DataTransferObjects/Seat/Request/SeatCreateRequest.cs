using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Seat.Request
{
    public class SeatCreateRequest
    {
        public Guid RoomLayoutId { get; set; }
        public string Code { get; set; }
        public string Row { get; set; }
        public int SeatColumn { get; set; }
        public EntityTypeSeat Type { get; set; }
        public double Price { get; set; }
        public EntityStatus Status { get; set; }
    }
}
