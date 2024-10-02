using System.ComponentModel.DataAnnotations;

namespace URF_Cinema.Application.DataTransferObjects.Account
{
    public class ViewLoginInput
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
