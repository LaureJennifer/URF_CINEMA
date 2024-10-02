using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Customer.Request
{
    public class CustomerUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? UrlImage { get; set; }
        public string? UserName { get; set; }

        public string? PassWord { get; set; }
        public EntityStatus Status { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
    }
}
