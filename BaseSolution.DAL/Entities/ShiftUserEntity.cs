namespace BaseSolution.Domain.Entities
{
    public class ShiftUserEntity
    {
        public Guid Id { get; set; }
        public Guid ShiftId { get; set; }
        public Guid UserId { get; set; }
        public virtual ShiftEntity Shift{ get; set; }
        public virtual UserEntity User{ get; set; }
    }
}
