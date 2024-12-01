using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.DashboardUserDto.Update;

public class DashboardPasswordInitialDto
{
    public int Id { get; set; }
    [DataType("Password")]
    [Required(ErrorMessage = "الرجاء إدخال كلمة المرور الحالية")]
    [Display(Name = "كلمة المرور الحالية")]
    public string CurrentPassword { get; set; } = string.Empty;
    [DataType("Password")]
    [Required(ErrorMessage = "الرجاء إدخال كلمة المرور الجديدة")]
    [Display(Name = " كلمة المرور الجديدة")]
    // (?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&!"£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-])[A-Za-z\d$@!%*?&!"£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-]{8,}
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&!£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-])[A-Za-z\d$@!%*?&!£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-]{8,}$", ErrorMessage = "كلمة المرور يجب أن تكون 8 حروف وارقام على الأقل , كلمة المرور يجب أن تحتوي على حرف كبير على الأقل , كلمة المرور يجب أن تحتوى حلى حرف مميز على الاقل ")]
    public string Password { get; set; } = string.Empty;
    [DataType("Password")]
    [Compare("Password")]
    [Required(ErrorMessage = "كلمة المرور يجب أن تكون متطابقة")]
    [Display(Name = "تأكيد كلمة المرور")]
    public string ConfirmPassword { get; set; } = string.Empty;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool IsFirstLogin { get; set; }
}
