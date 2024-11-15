using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApi.Dtos.PortalUserModelDto.Insert;

public class InsertPortalUserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال الإدارة")]
    [Display(Name = "رقم الهوية")]
    public string NationalId { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الاسم")]
    [Display(Name = "الاسم")]
    public string UserFullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال البريد الالكتروني")]
    [Display(Name = "البريد الالكتروني")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الصورة الشخصية")]
    [Display(Name = "الصورة الشخصية")]
    public int PersonalImgId { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال نوع المستخدم")]
    [Display(Name = "نوع المستخدم")] public string PhoneNumber { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public string LoginAttemp { get; set; } = string.Empty;
    public string LastLogin { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
}
