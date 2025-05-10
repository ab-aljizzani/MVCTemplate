using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.RoleDto;

namespace ClinicApi.Dtos.PortalUserModelDto.Insert;

public class InsertPortalUserDto
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
    [Display(Name = "كلمة المرور")]
    [DataType("Password")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الهوية")]
    [Display(Name = "رقم الهوية")]
    public string NationalId { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الاسم الكامل")]
    [Display(Name = "الاسم الكامل")]
    public string UserFullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال البريد الالكتروني")]
    [Display(Name = "البريد الالكتروني")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public int PersonalImgId { get; set; }
    public string EmpIamImgUrl { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال نوع المستخدم")]
    [Display(Name = "نوع المستخدم")]
    public string UserType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    public string PhoneNumber { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsFirstLogin { get; set; } = false;
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public int LoginAttemp { get; set; }
    public string LastLogin { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsFromShamel { get; set; } = false;
}
