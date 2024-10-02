using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Room.Request
{
    public class RoomUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? RoomLayoutId { get; set; }
        public Guid? DepartmentId { get; set; }
        public int? Capacity { get; set; } //Sức chứa
        public string? Code { get; set; }
        public string? SoundSystem { get; set; }
        public string? ScreenSize { get; set; }
        public EntityStatus? Status { get; set; }

    }
}
