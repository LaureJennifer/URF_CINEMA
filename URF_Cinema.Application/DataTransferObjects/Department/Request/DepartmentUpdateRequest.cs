using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Department.Request
{
    public class DepartmentUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AddressCode { get; set; }
        public string? AddressCodeFormat { get; set; }
        public string? Address { get; set; }

        public EntityStatus? Status { get; set; }
    }
}
