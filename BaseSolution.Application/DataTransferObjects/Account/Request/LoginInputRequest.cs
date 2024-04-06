using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Account.Request
{
    public class LoginInputRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserRoleId { get; set; }
        public class LoginValication : AbstractValidator<LoginInputRequest>
        {
            public LoginValication()
            {
                RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
                RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
                RuleFor(x => x.UserRoleId).NotEmpty().WithMessage("UserRoleId is required");
            }
        }
    }
}
