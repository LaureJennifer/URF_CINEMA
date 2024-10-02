using System.ComponentModel.DataAnnotations;

namespace URF_Cinema.Application.DataTransferObjects
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
