using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.User.Request
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UrlImage { get; set; }

        public string? PassWord { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
