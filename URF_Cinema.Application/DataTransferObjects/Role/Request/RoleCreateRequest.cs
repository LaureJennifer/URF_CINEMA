using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Role.Request
{
    public class RoleCreateRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
