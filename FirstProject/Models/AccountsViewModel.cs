using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(300)]
        [EmailAddress(ErrorMessage = "ادرس ایمیل نادرست است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "رمز عبور همخوانی ندارد")]
        [Display(Name = "تکرار رمز عبور")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(300)]
        [EmailAddress(ErrorMessage = "ادرس ایمیل نادرست است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
        
    }
}
