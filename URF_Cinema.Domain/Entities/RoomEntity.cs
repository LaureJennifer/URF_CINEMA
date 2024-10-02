using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class RoomEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid RoomLayoutId { get; set; }
        public Guid DepartmentId { get; set; }
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string? SoundSystem { get; set; }
        public string? ScreenSize { get; set; }
        public string? RoomType { get; set; }  //Loại phòng
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual RoomLayoutEntity RoomLayout{ get; set; }
        public virtual DepartmentEntity Department { get; set; }
        public virtual List<BookingEntity> Bookings { get; set; }
        public virtual List<FilmScheduleRoomEntity> FilmScheduleRooms { get; set; }
    }
}
