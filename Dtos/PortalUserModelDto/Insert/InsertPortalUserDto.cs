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
    public string Password { get; set; } = string.Empty;

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
    // [NotMapped]
    // public PersonalImgDto? PersonalImage { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال نوع المستخدم")]
    [Display(Name = "نوع المستخدم")]
    public string UserType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    public string PhoneNumber { get; set; } = string.Empty;
    public int EntityId { get; set; }
    // [NotMapped]
    // public GetEntityDto? Entity { get; set; }
    public int DepartmentId { get; set; }
    // [NotMapped]
    // public DepartmentDto? DepartmentDto { get; set; }
    public int RoleId { get; set; }
    // [NotMapped]
    // public RoleDto.RoleDto? Role { get; set; }
    public string LoginAttemp { get; set; } = string.Empty;
    public string LastLogin { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
}
