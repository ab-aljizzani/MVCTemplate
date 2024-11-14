using System.ComponentModel.DataAnnotations;
using ClinicApi.Data.PersonalImagesModelDto;



namespace ClinicApi.Dtos.PersonModelDto;

public class PersonDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال رقم الهوية الوطنية")]
    [Display(Name = "الهوية الوطنية")]
    public string NationalId { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الرتبة")]
    [Display(Name = "الرتبة")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الإسم العربي")]
    [Display(Name = "الإسم العربي")]
    public string FullArabicName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال الإسم الإنجليزي")]
    [Display(Name = "الإسم الإنجليزي")]
    public string FullEnglishName { get; set; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
    [Required(ErrorMessage = "الرجاء إدخال تاريخ الميلاد")]
    [Display(Name = "تاريخ الميلاد")]
    public string DateOfBirth { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال رقم الجوال")]
    [Display(Name = "رقم الجوال")]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار منطقة القرب ")]
    [Display(Name = "منطقة القرب")]
    public int ZoneId { get; set; }
    public Dtos.ZoneModelDto.ZoneDto? Zone { get; set; }
    public int EntityId { get; set; }
    public Models.Entity.Entity? Entity { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار الإدارة ")]
    [Display(Name = "الإدارة")]
    public int DepartmentId { get; set; }
    public Dtos.Entity.DepartmentDto? Department { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار نوع الهوية ")]
    [Display(Name = "نوع الهوية")]
    public string NationalIdType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال المسمى الوظيفي ")]
    [Display(Name = "المسمى الوظيفي")]
    public string JobTitle { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار المرتبة الوظيفية ")]
    [Display(Name = "المرتبة الوظيفية")]
    public string Grade { get; set; } = string.Empty;
    public int PersonalImgId { get; set; }
    public PersonalImgDto? PersonalImg { get; set; }
}
