using URF_Cinema.Domain.Entities.Base;
using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class RoleEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public virtual List<UserEntity> Users { get; set; }
    }
}
