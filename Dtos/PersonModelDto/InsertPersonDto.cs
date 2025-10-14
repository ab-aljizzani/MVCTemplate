using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.PersonModelDto;

public class InsertPersonDto
{
    [Required(ErrorMessage = "الرجاء إدخال رقم الهوية الوطنية")]
    [Display(Name = "الهوية الوطنية")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "رقم الهوية الوطنية يجب أن يتكون من 10 أرقام")]
    public string NationalId { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الرتبة")]
    [Display(Name = "الرتبة")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الإسم العربي")]
    [Display(Name = "الإسم العربي")]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "الإسم العربي يجب أن يحتوي على حروف وأرقام فقط")]
    public string FullArabicName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الإسم الإنجليزي")]
    [Display(Name = "الإسم الإنجليزي")]
    [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "الإسم الإنجليزي يجب أن يحتوي على حروف وأرقام فقط")]
    public string FullEnglishName { get; set; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    [Phone(ErrorMessage = "الرجاء إدخال رقم جوال صحيح")]
    public string PhoneNumber { get; set; } = string.Empty;
    public int ZoneId { get; set; }
    public int EntityId { get; set; }
    public int PersonalImgId { get; set; }
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار الجنسية ")]
    [Display(Name = "الجنسية")]
    public string NationalIdType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال المسمى الوظيفي ")]
    [Display(Name = "المسمى الوظيفي")]
    public string JobTitle { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار المرتبة الوظيفية ")]
    [Display(Name = "المرتبة الوظيفية")]
    public string Grade { get; set; } = string.Empty;
    public int? RoleId { get; set; } = 8;
}
