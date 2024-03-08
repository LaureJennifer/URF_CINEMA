using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RoomEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid RoomLayoutId { get; set; }
        public Guid DepartmentId { get; set; }
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public RoomLayoutEntity RoomLayoutEntity { get; set; }
        public DepartmentEntity DepartmentEntity { get; set; }
        public List<BookingEntity> Bookings { get; set; }
        public List<FilmScheduleRoomEntity> FilmScheduleRooms { get; set; }
    }
}
