using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;

namespace BaseSolution.Domain.Entities
{
    public class ShiftEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset ShiftDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<ShiftDepartmentEntity> ShiftDepartments { get; set; }
        public virtual List<ShiftUserEntity> ShiftUsers { get; set; }
    }
}
