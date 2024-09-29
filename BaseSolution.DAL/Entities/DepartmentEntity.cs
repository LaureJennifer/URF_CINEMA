using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class DepartmentEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }
        public string AddressCode { get; set; }
        public string Address { get; set; }

        public double? Latitude { get; set; } // Vĩ độ
        public double? Longitude { get; set; } // Kinh độ
        public string? OpeningHours { get; set; } // Giờ mở cửa
        public string? ClosingHours { get; set; } // Giờ đóng cửa
        public EntityStatus Status { get; set; }
        public virtual List<DepartmentFilmEntity> DepartmentFilms { get; set; }
        public virtual List<BillEntity> Bills { get; set; }
        public virtual List<BookingEntity> Bookings { get; set; }
        public virtual List<UserEntity> Users { get; set; }
        public virtual List<RoomEntity> Rooms { get; set; }
        public virtual List<DepartmentProductEntity> DepartmentProducts { get; set; }
        public virtual List<ShiftDepartmentEntity> ShiftDepartments { get; set; }
    }
}
