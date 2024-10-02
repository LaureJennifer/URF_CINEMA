using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace URF_Cinema.Application.DataTransferObjects.Account.Request
{
    public class LoginInputRequest
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public class LoginValication : AbstractValidator<LoginInputRequest>
        {
            public LoginValication()
            {
                RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
                RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            }
        }
    }
}
