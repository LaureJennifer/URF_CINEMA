using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.RoomLayout
{
    public class RoomLayoutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
