using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyTypeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال اسم النموذج ")]
    [Display(Name = "اسم النموذج")]
    public string Type { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال اسم النموذج بالإنجليزي ")]
    [Display(Name = "اسم النموذج بالإنجليزي")]
    public string EngType { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار اسم نوع النموذج ")]
    [Display(Name = "نوع النموذج ")]
    public string TypeRole { get; set; } = string.Empty;
}
