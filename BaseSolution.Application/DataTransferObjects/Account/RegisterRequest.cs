using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Account
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        [MaxLength(128, ErrorMessage = "Tên người dùng không được vượt quá 128 ký tự!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Tên người dùng không được chứa ký tự đặc biệt!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(20, MinimumLength = 6,ErrorMessage = "Mật khẩu không được ít hơn 6 ký tự và nhiều hơn 20 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất một chữ hoa, một chữ thường và một chữ số")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Địa chỉ Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ!")]
        [MaxLength(128, ErrorMessage = "Địa chỉ Email dùng không được vượt quá 128 ký tự!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        [MaxLength(128, ErrorMessage = "Tên người dùng không được vượt quá 128 ký tự!")]
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Code { get; set; } = null;
        public string Address { get; set; }
        public string IdentificationNumber { get; set; } = string.Empty;
        public string UrlImage { get; set; }
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống!")]
        public string ConfirmPassword { get; set; }
    }
}
