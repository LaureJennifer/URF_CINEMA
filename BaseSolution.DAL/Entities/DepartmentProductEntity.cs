namespace BaseSolution.Domain.Entities
{
    public class DepartmentProductEntity
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ProductId { get; set; }
        public virtual DepartmentEntity Department { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
