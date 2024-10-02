using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request
{
    public class FilmScheduleRoomUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? FilmScheduleId { get; set; }
        public Guid? RoomId { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
