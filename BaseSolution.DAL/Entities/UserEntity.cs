using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset StartTime { get; set; } // Thời gian bắt đầu làm việc
        public string EducationLevel { get; set; } // Trình độ học vấn
        public string  UrlImage { get; set; }

        public string PassWord { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual RoleEntity Role { get; set; }

        public virtual List<ShiftUserEntity> ShiftUsers { get; set; }
        public virtual List<TicketEntity> Tickets { get; set; }
        public virtual List<BookingEntity> Bookings { get; set; }
        public virtual List<BillEntity> Bills { get; set; }

    }
}
