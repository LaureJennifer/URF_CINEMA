using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.RoomLayout.Request
{
    public class RoomLayoutUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
