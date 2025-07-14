using System;
using System.ComponentModel.DataAnnotations;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Models.Entity;

namespace ClinicApi.Dtos.PortalUserDto;

public class PortalUserDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال اسم المستخدم")]
    [Display(Name = "اسم المستخدم")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال كلمة المرور")]
    [Display(Name = "كلمة المرور")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&!£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-])[A-Za-z\d$@!%*?&!£$%^&*()_+{}:@~<>?|=[\];'#,.\/\\-]{8,}$", ErrorMessage = "كلمة المرور يجب أن تكون 8 حروف وارقام على الأقل , كلمة المرور يجب أن تحتوي على حرف كبير على الأقل , كلمة المرور يجب أن تحتوى حلى حرف مميز على الاقل ")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "كلمة المرور يجب أن تكون متطابقة")]
    [Display(Name = "تاكيد كلمة المرور")]
    [DataType("Password")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الهوية")]
    [Display(Name = "رقم الهوية")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "رقم الهوية يجب أن يتكون من 10 أرقام")]
    public string NationalId { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال الاسم الكامل")]
    [Display(Name = "الاسم الكامل")]
    [RegularExpression(@"^[\u0600-\u06FFa-zA-Z\s]+$", ErrorMessage = "الاسم الكامل يجب أن يحتوي على حروف فقط")]
    public string UserFullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال البريد الالكتروني")]
    [Display(Name = "البريد الالكتروني")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الصورة الشخصية")]
    [Display(Name = "الصورة الشخصية")]
    public int PersonalImgId { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool IsFirstLogin { get; set; } = false;
    public Models.PersonalImagesModel.PersonalImg? PersonalImage { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال نوع المستخدم")]
    [Display(Name = "نوع المستخدم")]
    public string UserType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    [Phone(ErrorMessage = "الرجاء إدخال رقم جوال صحيح")]
    public string PhoneNumber { get; set; } = string.Empty;
    public Models.Entity.Entity? Entity { get; set; }
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public Models.Entity.Department? Department { get; set; }
    public int RoleId { get; set; }
    public Models.Role.Role? Role { get; set; }
    public int LoginAttemp { get; set; }
    public string LastLogin { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsFromShamel { get; set; } = false;
}
