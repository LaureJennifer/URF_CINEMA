using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Role
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
