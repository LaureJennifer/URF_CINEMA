namespace BaseSolution.Domain.Entities
{
    public class ShiftDepartmentEntity
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ShiftId { get; set; }
        public virtual DepartmentEntity Department { get; set; }
        public virtual ShiftEntity Shift { get; set; }
    }
}
