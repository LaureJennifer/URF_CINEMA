using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }
        [Required,MinLength(6,ErrorMessage = "Xin nhập ít nhất 6 ký tự")]
        public string Password { get; set; }
        [Required,Compare("Password")]
        public string ConfirmPassword {  get; set; }
    }
}
