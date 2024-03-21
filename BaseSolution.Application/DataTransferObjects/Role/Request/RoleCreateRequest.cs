using BaseSolution.Domain.Enums;

namespace BaseSolution.Application.DataTransferObjects.Role.Request
{
    public class RoleCreateRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
