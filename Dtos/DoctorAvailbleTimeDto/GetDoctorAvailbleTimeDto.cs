using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.DoctorAvailbleTimeDto;

public class GetDoctorAvailbleTimeDto
{
    public int Id { get; set; }
    public int PortalUserId { get; set; }

    [Required(ErrorMessage = "الرجاء إدخال تاريخ بداية المواعيد")]
    [Display(Name = "تاريخ بداية المواعيد")]
    public string StartDate { get; set; }

    [Required(ErrorMessage = "الرجاء إدخال تاريخ نهاية المواعيد")]
    [Display(Name = "تاريخ نهاية المواعيد")]
    public string EndDate { get; set; }

    [Required(ErrorMessage = "الرجاء إدخال وقت بداية المواعيد")]
    [Display(Name = "وقت بداية المواعيد")]
    public string StartTime { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إدخال وقت نهاية المواعيد")]
    [Display(Name = "وقت نهاية المواعيد")]
    public string EndTime { get; set; } = string.Empty;


    [Required(ErrorMessage = "الرجاء إدخال الوقت بين المواعيد بالدقائق")]
    [Display(Name = "الوقت بين المواعيد بالدقائق")]
    public string TimeInBetween { get; set; } = string.Empty;
}
